//using System;
//using System.Collections.Generic;
//using Antlr4.Runtime;
//using Antlr4.Runtime.Tree; 
//using System.Linq;

// namespace netcorejavast
// {
//    public class ASTBuilder
//    {
//        public static int parserRulesCount=0;
//        public static int terminalsCount=0;
//        public static int othersCount=0;
//        public static FileASTnode fileASTnode=null;

//        private static ASTnode BuildASTFromParseTree(IParseTree parseTreeNode,ASTnode parentASTnode) 
//        {
//            ASTBuilder.UpdateCounters(parseTreeNode);
//            ASTnode newASTnode =null;
//            newASTnode=ParseTreeNodeProcessor.Process(parseTreeNode);

//            if(newASTnode==null)
//            {
//                if(parseTreeNode is IErrorNode){
//                  //  Console.WriteLine(((IErrorNode)parseTreeNode).GetType().Name.ToString());
//                } 
//                else if (parseTreeNode is IRuleNode)
//                {
//                   // Console.WriteLine(((IRuleNode)parseTreeNode).GetType().Name.ToString() + " " + parseTreeNode.GetText());
//                }
//                else if(parseTreeNode is ITerminalNode)
//                {
//                  //  Console.WriteLine(((ITerminalNode)parseTreeNode).GetType().Name.ToString());
//                  //  Console.WriteLine(parseTreeNode.GetText());
//                }
//            }

//            if(newASTnode!=null)
//            {
//               // Console.WriteLine(newASTnode.Text);
//            }
//            for (int i = 0; i < parseTreeNode.ChildCount; i++) 
//            {  
//                IParseTree child = parseTreeNode.GetChild(i);
//                if(newASTnode==null){
//                    newASTnode=parentASTnode;
//                }
//                ASTnode childASTnode=BuildASTFromParseTree(child,newASTnode); 
//                if(newASTnode!=null && childASTnode!=null && newASTnode!=childASTnode)
//                {
//                    newASTnode.Children.Add(childASTnode);
//                }
//            }
                
//            return newASTnode;
//        } // function

//        public static ASTnode BuildASTFromParseTree(string[] _ruleNames,IParseTree parseTreeNode) 
//        {
//            ParseTreeNodeProcessor.InitParseTreeNodeProcessor(_ruleNames.ToList());
//            return BuildASTFromParseTree(parseTreeNode,null);
//        }

//        private static void UpdateCounters(IParseTree parseTreeNode)
//        {
//            if(parseTreeNode is ParserRuleContext)
//            {
//                parserRulesCount++;
//            } else if(parseTreeNode is TerminalNodeImpl){
//                terminalsCount++;
//            } else {
//                othersCount++;
//            }
//        }
//    }
// }