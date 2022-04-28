using Antlr4.Runtime.Tree;
using netcorejavast.AST.Models;
using netcorejavast.AST.Processor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Antlr4.Runtime;

namespace netcorejavast.AST.Queries
{
    public class SecureCookieFlag : IQuery
    {
        private List<QueryFinding> _listoffindings { get; set; }

        public List<QueryFinding> processRequest()
        {
            _listoffindings = new List<QueryFinding>();
            var nodeList = JavaParserHelper.GetNodeListByRuleNameAndValue(ParserRules.TYPETYPE, "Cookie",ParserRules.BLOCKSTATEMENT);
            if (nodeList.Count == 0) return _listoffindings; // Return empty list

            foreach (var node in nodeList) {
                bool checkIfVulnerabilityExists = CheckIfVulnerabilityExists(node);
                if (checkIfVulnerabilityExists) {
                    QueryFinding finding = new QueryFinding();
                    finding.LineNumber = JavaParserHelper.GetLineNumberOfNode(node);
                    finding.Reason = "Secure Cookie Flag Vulnerability";
                    finding.Severity = Severity.Critical;
                    _listoffindings.Add(finding);
                }
            }
            return _listoffindings;

        }

        private bool CheckIfVulnerabilityExists(IParseTree node) {
            ParserRuleContext variabledeclaratornode =(ParserRuleContext)JavaParserHelper.GetParticularNodesFromRootNodeAndRule(node,ParserRules.VARIABLEDECLARATOR).FirstOrDefault();
            if (variabledeclaratornode != null) {
                string instance_variable_name = variabledeclaratornode.Start.Text;
                var parentblocknode = JavaParserHelper.GetParentNodeFromRootNodeAndRule(node, ParserRules.BLOCK);
                int newOperatorLineNumber=0;
                bool checkIfInstanceCreatedUsingNewOperator = checkIfInstanceCreatedForTheVariableUsingNewOperator(parentblocknode, variabledeclaratornode, instance_variable_name, JavaParserHelper.GetLineNumberOfNode(node), "Cookie",ref newOperatorLineNumber);
                if (!checkIfInstanceCreatedUsingNewOperator) {
                    return false; //If the variable is not instantiated using new operator, we are not doing futher checks.
                }
                var methodCallNodes = JavaParserHelper.SearchNodesInTheBlockByLineNumberAndRule(parentblocknode,Search.AFTERLINE,JavaParserHelper.GetLineNumberOfNode(node),ParserRules.METHODCALL,StartText: "setSecure");
                if (methodCallNodes.Count > 0)
                {
                    foreach (var methodnode in methodCallNodes) {
                        if ((((ParserRuleContext)methodnode.Parent).Start.Text == instance_variable_name) || (((ParserRuleContext)methodnode.Parent).Start.Text == "new" &&  JavaParserHelper.GetLineNumberOfNode(methodnode.Parent)== newOperatorLineNumber)) {
                            ParserRuleContext methodcall_value_node = (ParserRuleContext)JavaParserHelper.GetParticularNodesFromRootNodeAndRule(methodnode, ParserRules.EXPRESSION).FirstOrDefault();
                            return !(methodcall_value_node.Start.Text == "true");
                        }
                    }
                   
                }
                return true;
            }
            return false;
        }

        private bool checkIfInstanceCreatedForTheVariableUsingNewOperator(IParseTree parentblocknode,IParseTree variabledeclaratornode, string instance_variable_name,int line,string class_name,ref int LineNewOperator) {
            var NewOperatorNodeIfInSameLineOfVariableDeclaratorNodes = JavaParserHelper.GetParticularNodesFromRootNodeAndRule(variabledeclaratornode, ParserRules.EXPRESSION, StartText: "new");
            foreach (var node in NewOperatorNodeIfInSameLineOfVariableDeclaratorNodes) {
                if (node.ChildCount>1 && node.GetChild(1).ChildCount>1 && ((ParserRuleContext)node.GetChild(1)).Start.Text == class_name)
                {
                    LineNewOperator = JavaParserHelper.GetLineNumberOfNode(node);
                    return true;
                }
            }
            var new_operator_instances = JavaParserHelper.SearchNodesInTheBlockByLineNumberAndRule(parentblocknode, Search.AFTERLINE, line, ParserRules.EXPRESSION, StartText: "new");
            foreach (var instance in new_operator_instances) {
                if (((ParserRuleContext)instance.Parent).Start.Text==instance_variable_name && ((ParserRuleContext)instance.GetChild(1)).Start.Text==class_name) {
                    LineNewOperator = JavaParserHelper.GetLineNumberOfNode(instance);
                    return true;
                }
            }
            return false;     
        }
    }
}
