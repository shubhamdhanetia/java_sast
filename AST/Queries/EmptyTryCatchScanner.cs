using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using netcorejavast.AST.Models;
using netcorejavast.AST.Processor;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcorejavast.AST.Queries
{
    public class EmptyTryCatchScanner : IQuery
    {
        private List<QueryFinding> _queryFindings;
        private List<IParseTree> _emptyTryNodes;
        private List<IParseTree> _emptyCatchNodes;
        public void printResult()
        {
            throw new NotImplementedException();
        }

        public List<QueryFinding> processRequest()
        {
            _queryFindings = new List<QueryFinding>();
            _emptyTryNodes = new List<IParseTree>();
            _emptyCatchNodes = new List<IParseTree>();
            var nodes = JavaParserHelper.GetTryNodes();

            
            foreach (var node in nodes)
            {
                for (int i = 0; i < node.ChildCount; i++) {

                    if (node.GetChild(i).ChildCount > 0 && JavaParserHelper.GetRuleName(node.GetChild(i)) == ParserRules.BLOCK) {

                        if (node.GetChild(i).ChildCount == 2) {
                            QueryFinding finding = new QueryFinding();
                            finding.Reason = "Empty Try Block";
                            finding.LineNumber = ((ParserRuleContext)node).Start.Line;
                            finding.Severity = Severity.Low;
                            _queryFindings.Add(finding);
                            _emptyTryNodes.Add(node.GetChild(i));
                        }
                       
                    } else if (node.GetChild(i).ChildCount > 0 && JavaParserHelper.GetRuleName(node.GetChild(i)) == ParserRules.CATCHCLAUSE) {

                        var catchnode = node.GetChild(i);
                        if (catchnode.GetChild(catchnode.ChildCount - 1).ChildCount == 2) {
                            QueryFinding finding = new QueryFinding();
                            finding.Reason = "Empty Catch Block";
                            finding.LineNumber = ((ParserRuleContext)catchnode).Start.Line;
                            finding.Severity = Severity.Low;
                            finding.AffectedLineCode = catchnode.GetText();
                            _queryFindings.Add(finding);
                            _emptyCatchNodes.Add(catchnode);
                        }

                    }
                
                }

            }
            return _queryFindings;
        }
    }
}
