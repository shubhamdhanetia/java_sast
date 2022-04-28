//using System.Collections.Generic;
//using Antlr4.Runtime.Tree;
//using System;
//using Antlr4.Runtime;
//using System.Linq;
//using netcorejavast.AST.Models;

//namespace netcorejavast
//{
//    public class ParseTreeNodeProcessor
//    {
//        public static List<string> rules;
//        private static Dictionary<string,Func<IParseTree,ASTnode>> processors=new Dictionary<string, Func<IParseTree, ASTnode>>();


//        public static void  InitParseTreeNodeProcessor(List<string> _rules)
//        {
//            rules=_rules;
//            AddProcessors();
//        }

//        public static ASTnode Process(IParseTree node)
//        {
//            if(node is ParserRuleContext){    
//                string rule=ParseTreeNodeProcessor.GetRuleName(node);
//                if(processors.ContainsKey(rule))
//                {
//                    return processors[rule](node);
//                }
//            }
//            return null;
//        }

//        public static ASTnode ProcessCompilationUnit(IParseTree node)
//        {
//            //Console.WriteLine("Compilation");
//            FileASTnode fileASTnode=new FileASTnode(null);
//            ASTBuilder.fileASTnode=fileASTnode;
//            return fileASTnode;
//        }

//        public static ASTnode ProcessPackageDeclaration(IParseTree node)
//        { 
//          //  Console.WriteLine("Package");
//            string packageName=node.GetChild(1).GetText();
//            ASTBuilder.fileASTnode.Package=packageName;
//            return new PackageASTnode(ASTBuilder.fileASTnode,packageName);
//        }

//        public static ASTnode ProcessImportDeclaration(IParseTree node)
//        {
//            //Console.WriteLine("Import");
//            string packageName=node.GetChild(1).GetText();
//            ImportASTnode importASTnode= new ImportASTnode(ASTBuilder.fileASTnode,packageName);
//            ASTBuilder.fileASTnode.imports.Add(importASTnode);
//            return importASTnode;
//        }

//        public static ASTnode ProcessTypeDeclaration(IParseTree node)
//        {
//            ASTnode newNode=null;
         
//            if(node.ChildCount>0)
//            {
                
//                IParseTree childNode=node.GetChild(node.ChildCount-1); // <== Class Declaration Node

//                string localRulename=GetRuleName((ParserRuleContext)childNode);
//                if(localRulename.Equals("classDeclaration"))
//                {
//                    return ProcessClassDeclaration(childNode);
//                }
//                if(localRulename.Equals("interfaceDeclaration")) 
//                {
//                    string name =childNode.GetChild(1).GetText();
//                    string scope="internal";
//                        if(node.ChildCount>1){
//                        scope=node.GetChild(node.ChildCount-2).GetText();
//                    }
//                    InterfaceASTnode interfaceNode=new InterfaceASTnode(ASTBuilder.fileASTnode,name,scope);
//                  //   Console.WriteLine(interfaceNode.Text);
//                    //ASTnodeBuilder.PrintChildNodes(node);
//                }
                
//            }
//            return newNode;
           
//        }

//        public static ASTnode ProcessField(IParseTree node)
//        {
//          //  ParseTreeUtil.PrintChildrenWithTypeInfo(node);
//            return null;
//        }

//        public static ASTnode ProcessMethod(IParseTree node)
//        {
//            //MainBodyAST mainBody = new MainBodyAST();
//            //mainBody.ProcessMainBody(node.GetChild(node.ChildCount-1), rules);

//            ParseTreeUtil.PrintChildrenWithTypeInfo(node.GetChild(0));
//            return null;
//        }
//        public static ASTnode ProcessClassBody(IParseTree node,ASTnode classNode)
//        {
//           // Console.WriteLine("class body");
//            IParseTree bodyNode=node.GetChild(1);
//            List<string> modifiers=new List<string>();
//            for(int j=0;j<bodyNode.ChildCount-1;j++)
//            {    
//                modifiers.Add(bodyNode.GetChild(j).GetText());
//                //Console.WriteLine(j + ") " +bodyNode.GetChild(j).GetText() + " ==> " +bodyNode.GetChild(j).GetType().ToString());
//            }
//            IParseTree memberNode = bodyNode.GetChild(bodyNode.ChildCount-1);
            
//            if(GetRuleName(memberNode.GetChild(0)).Equals("fieldDeclaration"))
//            {
//                return ProcessField(memberNode);
//            } 
//            else if (GetRuleName(memberNode.GetChild(0)).Equals("methodDeclaration"))
//            {
//                return ProcessMethod(memberNode);
//            }
//            return null;
//        }

//        public static ASTnode ProcessClassDeclaration(IParseTree childNode)
//        { 
//            string extends=String.Empty;
//            string[] implements=null;
//            string name = childNode.GetChild(1).GetText();
//            string scope="internal";

//            if(childNode.Parent.ChildCount>1){
//                scope=childNode.Parent.GetChild(childNode.Parent.ChildCount-2).GetText();
//            }

//            ClassASTnode classNode= new ClassASTnode(ASTBuilder.fileASTnode,name,scope,extends,implements);

//             for(int i=0;i<childNode.ChildCount;i++)
//            {
//                IParseTree grandChild=childNode.GetChild(i);
//                if(grandChild is ParserRuleContext)
//                {
//                    string grandChildRulename=GetRuleName((ParserRuleContext)grandChild);   
//                    if(grandChildRulename.Equals("typeType"))
//                    {
//                            Console.WriteLine();
//                        //Console.WriteLine("===============Extends==============");
//                        extends = childNode.GetChild(i).GetText();
//                        //Console.WriteLine("Extends : " + extends);
//                    }

//                    if(grandChildRulename.Equals("typeList"))
//                    {
//                            Console.WriteLine();
//                        //Console.WriteLine("===============implements==============");
//                        implements = childNode.GetChild(i).GetText().Split(",");
//                        //Console.WriteLine("Implements : " + string.Join(',',implements));
//                        // Console.WriteLine("Implements : " +childNode.GetChild(i).GetText());
//                    }

//                    if(grandChildRulename.Equals("classBody"))
//                    {
//                       ProcessClassBody(grandChild,classNode);
//                    }
//                } 
                
//             //   Console.WriteLine(i + ") " +grandChild.GetText() + " ==> " +grandChild.GetType().ToString());
                
//            }

//          //  Console.WriteLine( classNode.Text);
//            return classNode;
                    
                
//        }

//        private static string GetRuleName(IParseTree node){
//            string rule =null;
//            try
//            {
//                rule=  ParseTreeNodeProcessor.rules[((ParserRuleContext)node).RuleIndex];
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine("Exception occured while getting the rule name!");
//                Console.WriteLine(ex.ToString());
//            }
//            return rule;
//        }

//        private static void AddProcessors()
//        {
//            processors.Add("default", new Func<IParseTree, ASTnode>(ParseTreeNodeProcessor.Process));
//            processors.Add("compilationUnit", new Func<IParseTree, ASTnode>(ParseTreeNodeProcessor.ProcessCompilationUnit));
//            processors.Add("packageDeclaration", new Func<IParseTree, ASTnode>(ParseTreeNodeProcessor.ProcessPackageDeclaration));
//            processors.Add("importDeclaration", new Func<IParseTree, ASTnode>(ParseTreeNodeProcessor.ProcessImportDeclaration));
//            processors.Add("typeDeclaration",new Func<IParseTree, ASTnode>(ParseTreeNodeProcessor.ProcessTypeDeclaration));
//        }


//    } 
 
//}