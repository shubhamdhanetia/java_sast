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
    public class LdapInjectionScanner : IQuery
    {
        private List<QueryFinding> _queryFindings;

        public List<QueryFinding> processRequest()
        {
            _queryFindings = new List<QueryFinding>();

            var nodeList = JavaParserHelper.GetNodeListByRuleNameAndValue(ParserRules.TYPETYPE, "DirContext");
            nodeList.AddRange(JavaParserHelper.GetNodeListByRuleNameAndValue(ParserRules.TYPETYPE, "InitialLdapContext"));
            nodeList.AddRange(JavaParserHelper.GetNodeListByRuleNameAndValue(ParserRules.TYPETYPE, "InitialDirContext"));
            nodeList.AddRange(JavaParserHelper.GetNodeListByRuleNameAndValue(ParserRules.TYPETYPE, "LdapContext"));
            nodeList.AddRange(JavaParserHelper.GetNodeListByRuleNameAndValue(ParserRules.TYPETYPE, "EventDirContext"));
            if (nodeList.Count == 0) return _queryFindings; // Return empty list

            foreach (var node in nodeList)
            {
                //int VulnerabilityLine = 0;
                List<IParseTree> list = new List<IParseTree>();
                bool checkIfVulnerabilityExists = CheckIfVulnerabilityExists(node,ref list);
                if (checkIfVulnerabilityExists)
                {
                    foreach (var vulnerability in list) {
                        QueryFinding finding = new QueryFinding();
                         finding.LineNumber = JavaParserHelper.GetLineNumberOfNode(vulnerability); ;
                        finding.Reason = "LDAP Injection Vulnerability";
                        finding.Severity = Severity.Critical;
                        _queryFindings.Add(finding);
                    }

                }
            }
            return _queryFindings;
        }

        private bool CheckIfVulnerabilityExists(IParseTree node, ref List<IParseTree> findings) {
            bool final_result = false;
            IParseTree blocknode = null;
            String instancevariablename = null;
            if (JavaParserHelper.GetRuleName(node.Parent) == ParserRules.FORMALPARAMETER)
            {
                var parentnode = JavaParserHelper.GetParentNodeFromRootNodeAndRule(node, ParserRules.METHODDECLARATION);
                blocknode = JavaParserHelper.GetParticularNodesFromRootNodeAndRule(parentnode.GetChild(parentnode.ChildCount - 1), ParserRules.BLOCK).FirstOrDefault();
            } else if (JavaParserHelper.GetRuleName(node.Parent) == ParserRules.LOCALVARIABLEDECLARATION) {
                blocknode = JavaParserHelper.GetParentNodeFromRootNodeAndRule(node, ParserRules.BLOCK);
            }
            IParseTree instancenode = JavaParserHelper.GetParticularNodesFromRootNodeAndRule(node.Parent, ParserRules.VARIABLEDECLARATORID).FirstOrDefault();
            if (instancenode != null) instancevariablename = instancenode.GetText();
            var methodCallNodes = JavaParserHelper.SearchNodesInTheBlockByLineNumberAndRule(blocknode, Search.AFTERLINE, JavaParserHelper.GetLineNumberOfNode(node), ParserRules.METHODCALL, StartText: "search");
            if (methodCallNodes.Count > 0) {
                foreach (var methodnode in methodCallNodes)
                {
                    if ((((ParserRuleContext)methodnode.Parent).Start.Text == instancevariablename))
                    {
                        var expressionnode = JavaParserHelper.GetParticularNodesFromRootNodeAndRule(methodnode, ParserRules.EXPRESSIONLIST).FirstOrDefault();
                        if (expressionnode.ChildCount==5) {
                            bool result = CheckIfTheExpressionIsVulnerable(expressionnode,blocknode);
                            if (result) {
                                findings.Add(expressionnode);
                                final_result = true;
                            } 
                        }
                    }
                }
                    
            
            }
            return final_result;
        }

        private bool CheckIfTheExpressionIsVulnerable(IParseTree expression,IParseTree blocknode) {
            IParseTree filternode = expression.GetChild(2);
            String filtervariablename = null;
            if (filternode.ChildCount == 1 && filternode.GetText()[0]== '"') { return false; }  //Hard coded filter string
            if (filternode.ChildCount == 1 && filternode.GetText()[0] != '"') {
                filtervariablename = filternode.GetText();
                var filtervariabledeclaratornode = JavaParserHelper.SearchNodesInTheBlockByLineNumberAndRule(blocknode, Search.BEFORELINE, JavaParserHelper.GetLineNumberOfNode(expression), ParserRules.VARIABLEDECLARATOR, StartText: filtervariablename).LastOrDefault();
                if (filtervariabledeclaratornode!=null) {
                    var nodes = JavaParserHelper.GetParticularNodesFromRootNodeAndRule(filtervariabledeclaratornode, ParserRules.PRIMARY);
                    List<String> inputVariableList = new List<string>();
                    nodes.Where(p => p.GetText()[0] != '"').ToList().ForEach(x => inputVariableList.Add(x.GetText()));
                    inputVariableList.Remove(inputVariableList.Where(p => p.ToLower().Equals("string")).FirstOrDefault());
                    //return !CheckIfTheInputVariablesAreValidated(inputVariableList, blocknode, JavaParserHelper.GetLineNumberOfNode(expression));
                    return !CheckIfTheInputVariablesAreValidated(inputVariableList, blocknode, JavaParserHelper.GetLineNumberOfNode(filtervariabledeclaratornode));
                }
            }
            else if (filternode.ChildCount>1) {
                var nodes = JavaParserHelper.GetParticularNodesFromRootNodeAndRule(filternode, ParserRules.PRIMARY);
                List<String> inputVariableList = new List<string>();
                nodes.Where(p => p.GetText()[0] != '"').ToList().ForEach(x => inputVariableList.Add(x.GetText()));
                return !CheckIfTheInputVariablesAreValidated(inputVariableList, blocknode,JavaParserHelper.GetLineNumberOfNode(expression));
            }

            return false;
        }

        private bool CheckIfTheInputVariablesAreValidated(List<string> variable_name_list,IParseTree blocknode, int LineNumber) {
            var methodCallNodes = JavaParserHelper.SearchNodesInTheBlockByLineNumberAndRule(blocknode, Search.BEFORELINE, LineNumber, ParserRules.METHODCALL);
            methodCallNodes.Remove(methodCallNodes.Where(p=> ((ParserRuleContext)p).Start.Text.ToLower()== "format" && ((ParserRuleContext)p.Parent).Start.Text.ToLower() == "string").FirstOrDefault());
            foreach (var variable in variable_name_list) {
                bool temp = false;
                foreach (var method in methodCallNodes) {
                    if (JavaParserHelper.GetLineNumberOfNode(method) != LineNumber || (((ParserRuleContext)method).Start.Text!= "search" && JavaParserHelper.GetLineNumberOfNode(method) == LineNumber)) {
                        bool isInputVariableIsValidated = JavaParserHelper.CheckIfValueExistsInNodeForAParticularRule(method, ParserRules.PRIMARY, variable);
                        if (isInputVariableIsValidated) temp = true;
                    }                    
                }
                if (!temp) return false;
            }
            return true;
        }

    }
}
