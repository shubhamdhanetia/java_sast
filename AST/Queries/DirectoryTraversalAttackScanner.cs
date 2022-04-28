using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using netcorejavast.AST.Models;
using netcorejavast.AST.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace netcorejavast.AST.Queries
{
    public class DirectoryTraversalAttackScanner : IQuery
    {
        private List<QueryFinding> _listoffindings { get; set; }
        private List<IParseTree> _localvariablesnodes { get; set; }
        private List<IParseTree> _expressionnodes { get; set; }
        private List<IParseTree> _methodcalls { get; set; }

        public List<QueryFinding> processRequest()
        {
            _listoffindings = new List<QueryFinding>();
            _localvariablesnodes = JavaParserHelper.GetNodeListByRuleName(ParserRules.LOCALVARIABLEDECLARATION);
            _expressionnodes = JavaParserHelper.GetNodeListByRuleName(ParserRules.EXPRESSION);
            _methodcalls = JavaParserHelper.GetNodeListByRuleName(ParserRules.METHODCALL);

            foreach (var node in _localvariablesnodes)
            {                
                if (node.GetChild(0).GetText() == "Path" || node.GetChild(0).GetText() == "File")
                {
                    bool check = CheckIfVulnerabilityExists(node);
                    if (check) {
                        QueryFinding queryFinding = new QueryFinding();
                        queryFinding.LineNumber = ((ParserRuleContext)node).Start.Line;
                        queryFinding.Reason = "Directory Traversal Vulnerability";
                        queryFinding.Severity = Severity.Critical;
                        _listoffindings.Add(queryFinding);
                    }
                   
                }
               
            }

            return _listoffindings;
        }

        private Boolean CheckIfVulnerabilityExists(IParseTree node) {
            int LineNumber = ((ParserRuleContext)node).Start.Line;
            foreach (var exp_node in _expressionnodes)
            {
                if (((ParserRuleContext)exp_node).Start.Line == LineNumber)
                {
                    try {
                        if (exp_node.GetChild(0).GetText() == "Paths" && exp_node.GetChild(1).GetText() == "." && exp_node.GetChild(2).GetChild(0).GetText() == "get")
                        {
                            string functioncall_1 = exp_node.Parent.Parent.GetChild(0).GetText() + "." + "isAbsolute()";
                            string functioncall_2 = exp_node.Parent.Parent.GetChild(0).GetText() + "." + "normalize()";
                            string[] functional_calls = { functioncall_1, functioncall_2 };
                            foreach (var expobj in _expressionnodes)
                            {
                                if (functional_calls.Any(expobj.GetText().Contains)){
                                    return false;
                                }
                            }

                            IParseTree obj = exp_node.GetChild(2).GetChild(2).GetChild(0);
                            if (obj.ChildCount == 1)
                            {
                                char first_character = obj.GetText()[0];
                                if (first_character == '"')
                                { //To Check if the path is hard coded(It starts with quotes " " and no concatenation). If yes, then no Vulnerability.
                                    return false;
                                }
                                string file_variable_name = obj.GetText();
                                bool PathVariabeValidationResult = CheckIfInputPathVariableIsValidated(file_variable_name, node,true);
                                return !PathVariabeValidationResult;
                            }
                            else if (obj.ChildCount == 3)
                            {
                                if (obj.GetChild(0).GetText()[0] == '"' && obj.GetChild(1).GetText() == "+" && obj.GetChild(2).GetText()[0] != '"')
                                { // If path starts with quotes "" + concatenation of variable -> "C:/" + somevariable
                                    string variable_name = obj.GetChild(2).GetText();
                                    bool PathVariabeValidationResult = CheckIfInputPathVariableIsValidated(variable_name, node,true);
                                    return !PathVariabeValidationResult;

                                }
                                else if (obj.GetChild(0).GetText()[0] != '"' && obj.GetChild(1).GetText() == "+" && obj.GetChild(2).GetText()[0] != '"')
                                {  // variable + variable case -> baseDirectory + targetFile
                                    string base_directory_variable = obj.GetChild(0).GetText();
                                    string target_file_variable = obj.GetChild(2).GetText();
                                    bool PathVariabeValidationResult = CheckIfInputPathVariableIsValidated(target_file_variable, node,true);
                                    return !PathVariabeValidationResult;
                                }

                            }

                            return true;

                        } else if (exp_node.GetChild(0).GetText() == "new" && exp_node.GetChild(1).GetChild(0).GetText()=="File") {

                            string functioncall_1 = exp_node.Parent.Parent.GetChild(0).GetText() + "." + "isAbsolute()";
                            string functioncall_2 = exp_node.Parent.Parent.GetChild(0).GetText() + "." + "getCanonicalPath()";
                            string functioncall_3 = exp_node.Parent.Parent.GetChild(0).GetText() + "." + "getAbsolutePath()";
                            string[] functional_calls = { functioncall_1, functioncall_2, functioncall_3 };
                            foreach (var obj in _expressionnodes)
                            {
                                if (functional_calls.Any(obj.GetText().Contains))
                                {
                                    return false;
                                }
                            }

                            foreach (var obj in _expressionnodes) {

                                if (((ParserRuleContext)obj).Start.Line == LineNumber) {
                                    if (obj.GetChild(0).GetText() != "new") {
                                        if (obj.ChildCount == 1) {
                                            char first_character = obj.GetText()[0];
                                            if (first_character == '"') { //To Check if the path is hard coded(It starts with quotes " " and no concatenation). If yes, then no Vulnerability.
                                                return false;
                                            }
                                            string file_variable_name = obj.GetText();
                                            bool PathVariabeValidationResult= CheckIfInputPathVariableIsValidated(file_variable_name,node);
                                            return !PathVariabeValidationResult;
                                        }
                                        else if (obj.ChildCount == 3) {
                                            if (obj.GetChild(0).GetText()[0] == '"' && obj.GetChild(1).GetText() == "+" && obj.GetChild(2).GetText()[0] != '"') { // If path starts with quotes "" + concatenation of variable -> "C:/" + somevariable
                                                string variable_name = obj.GetChild(2).GetText();
                                                bool PathVariabeValidationResult = CheckIfInputPathVariableIsValidated(variable_name, node);
                                                return !PathVariabeValidationResult;

                                            } else if (obj.GetChild(0).GetText()[0] != '"' && obj.GetChild(1).GetText() == "+" && obj.GetChild(2).GetText()[0] != '"') {  // variable + variable case -> baseDirectory + targetFile
                                                string base_directory_variable = obj.GetChild(0).GetText();
                                                string target_file_variable = obj.GetChild(2).GetText();
                                                bool PathVariabeValidationResult = CheckIfInputPathVariableIsValidated(target_file_variable,node);
                                                return !PathVariabeValidationResult;
                                            }
                                        
                                        }
                                    }

                                
                                }
                            }
                            return true;
                        }
                    }
                    catch (Exception ex) { 
                    
                    }
                    break;
                }
            }
            return false;        
        }

        private bool CheckIfInputPathVariableIsValidated(String input_path_variable,IParseTree node,bool ? isPathVariable=false) {
            int LineNumber = ((ParserRuleContext)node).Start.Line;

            IParseTree methodbody = node;
            while (JavaParserHelper.GetRuleName(methodbody)!=ParserRules.METHODBODY) {
                methodbody = methodbody.Parent;            
            }
            var methodCallNodes = JavaParserHelper.GetParticularNodesFromRootNodeAndRule(methodbody, ParserRules.METHODCALL, LineNumber);
            bool result = false;
            foreach (var obj in methodCallNodes) {
                result = JavaParserHelper.CheckIfValueExistsInNodeForAParticularRule(obj, ParserRules.PRIMARY, input_path_variable);
                if (result)
                {
                    if (isPathVariable != null && isPathVariable == true)
                    {
                        if (obj.GetChild(0).GetText() != "get")
                        {
                            break;
                        }
                        else {
                            result = false;
                        }
                    }
                    else {
                        break;
                    }
                  
                }

            }
            return result;
        }
    }
}
