using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcorejavast.AST.Processor
{
    public class JavaParserHelper
    {
        public static Dictionary<string, List<IParseTree>> AstForAllRules = new Dictionary<string, List<IParseTree>>();

        public static List<string> rules = new List<string>();
        public static string current_file { get; set; }

        public static List<IParseTree> GetNodeListByRuleName(string rule)
        {
            if (AstForAllRules.ContainsKey(rule))
            {
                return AstForAllRules[rule];
            }
            return null;
        }
        public static string GetRuleName(IParseTree node)
        {
            string rule = null;
            try
            {
                rule = rules[((ParserRuleContext)node).RuleIndex];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rule;
        }

        public static List<IParseTree> GetTryNodes()
        {

            List<IParseTree> TryNodeList = new List<IParseTree>();
            var nodes = GetNodeListByRuleName(ParserRules.STATEMENT);
            foreach (var node in nodes)
            {

                if (node.GetChild(0).GetText() == "try")
                {
                    TryNodeList.Add(node);
                }

            }
            return TryNodeList;

        }

        public static List<IParseTree> GetTryCatchBlockNode()
        {

            List<IParseTree> tryCatchBlocklist = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("statement"))
            {
                var tryBlocklist = AstForAllRules["statement"];
                foreach (var node in tryBlocklist)
                {
                    if (node.GetChild(0).GetText() == "try")
                    {
                        if (node.GetChild(node.ChildCount - 1).GetChild(0).GetText() == "catch")
                        {
                            tryCatchBlocklist.Add(node);
                        }
                    }
                }
                return tryCatchBlocklist;
            }
            return null;
        }

        public static List<IParseTree> GetTryFinallyBlockNode()
        {

            List<IParseTree> tryFinallyBlocklist = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("statement"))
            {
                var tryBlocklist = AstForAllRules["statement"];
                foreach (var node in tryBlocklist)
                {
                    if (node.GetChild(0).GetText() == "try")
                    {

                        if (node.GetChild(node.ChildCount - 1).GetChild(0).GetText() == "finally" && node.GetChild(node.ChildCount - 2).GetChild(0).GetText() != "catch")
                        {
                            tryFinallyBlocklist.Add(node);
                        }
                    }
                }
                return tryFinallyBlocklist;
            }
            return null;
        }

        public static List<IParseTree> GetTryCatchFinallyBlockNode()
        {

            List<IParseTree> tryCatchFinallyBlocklist = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("statement"))
            {
                var tryBlocklist = AstForAllRules["statement"];
                foreach (var node in tryBlocklist)
                {
                    if (node.GetChild(0).GetText() == "try")
                    {

                        if (node.GetChild(node.ChildCount - 1).GetChild(0).GetText() == "finally" && node.GetChild(node.ChildCount - 2).GetChild(0).GetText() == "catch")
                        {
                            tryCatchFinallyBlocklist.Add(node);
                        }
                    }

                }
                return tryCatchFinallyBlocklist;
            }
            return null;
        }

        public static List<IParseTree> GetLocalVariables()
        {

            List<IParseTree> LocalVariablesNodes = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("localVariableDeclaration"))
            {
                var localvariableslist = AstForAllRules["localVariableDeclaration"];
                foreach (var node in localvariableslist)
                {
                    if (GetRuleName(node.Parent).Equals("blockStatement"))
                    {
                        LocalVariablesNodes.Add(node);
                    }
                }
                return LocalVariablesNodes;
            }
            return null;

        }

        public static List<IParseTree> GetInstanceVariables()
        {

            List<IParseTree> InstanceVariables = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("fieldDeclaration"))
            {
                var fieldDeclarationList = AstForAllRules["fieldDeclaration"];
                foreach (var node in fieldDeclarationList)
                {

                    if (node.Parent.Parent.ChildCount > 1)
                    {
                        //Condition Statement 1st Case : static int _staticVariable=100     //Condition Statement 2nd Case : public static final String str2="Learn Java Online";
                        if (node.Parent.Parent.GetChild(node.Parent.Parent.ChildCount - 2).GetText() == "static" || (node.Parent.Parent.ChildCount > 2 && node.Parent.Parent.GetChild(node.Parent.Parent.ChildCount - 3).GetText() == "static"))
                        {
                            //Static Variables
                        }
                        else
                        {
                            InstanceVariables.Add(node);
                        }
                    }
                    else
                    {
                        InstanceVariables.Add(node);
                    }

                }
                return InstanceVariables;
            }
            return null;

        }

        public static List<IParseTree> GetStaticVariables()
        {

            List<IParseTree> StaticVariables = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("fieldDeclaration"))
            {
                var fieldDeclarationList = AstForAllRules["fieldDeclaration"];
                foreach (var node in fieldDeclarationList)
                {

                    if (node.Parent.Parent.ChildCount > 1)
                    {
                        //Condition Statement 1st Case : static int _staticVariable=100     //Condition Statement 2nd Case : public static final String str2="Learn Java Online";
                        if (node.Parent.Parent.GetChild(node.Parent.Parent.ChildCount - 2).GetText() == "static" || (node.Parent.Parent.ChildCount > 2 && node.Parent.Parent.GetChild(node.Parent.Parent.ChildCount - 3).GetText() == "static"))
                        {
                            StaticVariables.Add(node);
                        }

                    }
                }
                return StaticVariables;
            }
            return null;

        }

        public static List<IParseTree> GetNormalClasses()
        {

            List<IParseTree> NormalClassList = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("classDeclaration"))
            {
                var Classes = AstForAllRules["classDeclaration"];
                foreach (var node in Classes)
                {
                    if (node.Parent.ChildCount == 1)
                    {
                        NormalClassList.Add(node);  //Normal Class
                    }
                    else
                    {
                        if (node.Parent.GetChild(node.Parent.ChildCount - 2).GetText() == "abstract")
                        {
                            //Abstract Class
                        }
                        else
                        {
                            NormalClassList.Add(node);
                        }
                    }
                }
                return NormalClassList;
            }
            return null;
        }

        public static List<IParseTree> GetAbstractClasses()
        {

            List<IParseTree> AbstractClassList = new List<IParseTree>();

            if (AstForAllRules.ContainsKey("classDeclaration"))
            {
                var Classes = AstForAllRules["classDeclaration"];
                foreach (var node in Classes)
                {
                    if (node.Parent.ChildCount > 1)
                    {
                        if (node.Parent.GetChild(node.Parent.ChildCount - 2).GetText() == "abstract")
                        {
                            AbstractClassList.Add(node);
                        }
                    }

                }
                return AbstractClassList;
            }
            return null;


        }

        public static void printHelper(string message, List<IParseTree> nodes)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine();
            foreach (var node in nodes)
            {

                for (int i = 0; i < node.ChildCount; i++)
                {
                    Console.WriteLine(node.GetChild(i).GetText());
                }
                Console.WriteLine();
            }

        }

        public static List<IParseTree> GetEmptyCatchBlockNodes()
        {

            List<IParseTree> EmptyCatchBlock = new List<IParseTree>();
            if (AstForAllRules.ContainsKey("catchClause"))
            {
                var catchClauseList = AstForAllRules["catchClause"];
                foreach (var node in catchClauseList)
                {

                    if (node.GetChild(node.ChildCount - 1).ChildCount == 2)
                    {
                        EmptyCatchBlock.Add(node);
                    }



                }
                return EmptyCatchBlock;
            }
            return null;

        }

        public static int GetLineNumberOfNode(IParseTree node) {
            int LineNumber = ((ParserRuleContext)node).Start.Line;
            return LineNumber;
        }

        public static List<IParseTree> GetNodeListByRuleNameAndValue(string rule,string value,string ? parentrulenode=null) {

            List<IParseTree> resultList = new List<IParseTree>();
            var nodes = JavaParserHelper.GetNodeListByRuleName(rule);
            foreach (var node in nodes) {
                if (node.GetText() == value)
                {
                    if (parentrulenode != null)
                    {

                        IParseTree parentnode = node;
                        while (JavaParserHelper.GetRuleName(parentnode) != parentrulenode)
                        {
                            parentnode = parentnode.Parent;
                        }
                        resultList.Add(parentnode);

                    }
                    else {
                        resultList.Add(node);
                    }
                   
                }                    
            }
            return resultList;        
        }

        public static bool CheckIfValueExistsInNodeForAParticularRule(IParseTree node,String rule,string value) {
            bool result = false;
            CheckIfValueExistsInNodeForAParticularRuleAndValue(node, ref result, rule, value);
            return result;
        }

        public static IParseTree GetNodeByParentRuleAndChildRuleAndValue(string parent_rule, string child_rule, string value) { 
        
        var nodes = JavaParserHelper.GetNodeListByRuleName(parent_rule);

            foreach (var node in nodes) {

                bool check = CheckIfValueExistsInNodeForAParticularRule(node, child_rule,value);
                if (check) {
                    return node;
                }
            
            }
            return null;

        }

        private static void CheckIfValueExistsInNodeForAParticularRuleAndValue(IParseTree node, ref bool result, String rule, string value) {
            if (node.ChildCount == 0) return;

            if (result == true) return;

            if (JavaParserHelper.GetRuleName(node) == rule && node.GetText()==value)
            {
                result = true;
            }
            for (int j = 0; j < node.ChildCount; j++)
            {
                CheckIfValueExistsInNodeForAParticularRuleAndValue(node.GetChild(j), ref result, rule, value);

            }

        }

        public static List<IParseTree> GetParticularNodesFromRootNodeAndRule(IParseTree root, String rule, int? LineNumberLimit=null,String ? StartText = null)
        {
            List<IParseTree> nodelist = new List<IParseTree>();
            GetParticularNodesFromRootNodeAndRule(root, rule,ref nodelist, LineNumberLimit,StartText);
            return nodelist;

        }

        public static IParseTree GetParentNodeFromRootNodeAndRule(IParseTree node,string rule) {
            while (JavaParserHelper.GetRuleName(node) != rule)
            {
                node = node.Parent;
            }
            return node;        
        }

        public static List<IParseTree> SearchNodesInTheBlockByLineNumberAndRule(IParseTree node, Search search, int LineNumber,string rule,string ? StartText=null) {
            List<IParseTree> nodelist = new List<IParseTree>();
            if (node.ChildCount == 0) return nodelist; //return empty list.

            for (int i = 0; i < node.ChildCount; i++) {

                if ((search == Search.BEFORELINE && node.GetChild(i).ChildCount>0 && GetLineNumberOfNode(node.GetChild(i)) <= LineNumber) || search == Search.AFTERLINE && node.GetChild(i).ChildCount > 0 && GetLineNumberOfNode(node.GetChild(i)) >= LineNumber) {

                    nodelist.AddRange(GetParticularNodesFromRootNodeAndRule(node.GetChild(i), rule,StartText:StartText));

                }

            }
            return nodelist;


        }

        private static void GetParticularNodesFromRootNodeAndRule(IParseTree node, String rule, ref List<IParseTree> result, int? LineNumberLimit,String ? StartText)
        {

            if (node.ChildCount == 0) return;

            if (LineNumberLimit != null)
            {
                int LineNumberOfNode = ((ParserRuleContext)node).Start.Line;
                if (LineNumberOfNode > LineNumberLimit)
                {
                    return;
                }
            }

            if (JavaParserHelper.GetRuleName(node) == rule)
            {
                if (StartText != null)
                {
                    if (((ParserRuleContext)node).Start.Text == StartText) {
                        result.Add(node);
                    }
                }
                else {
                    result.Add(node);
                }
             
            
            }

                for (int j = 0; j < node.ChildCount; j++)
                {
                GetParticularNodesFromRootNodeAndRule(node.GetChild(j), rule, ref result, LineNumberLimit,StartText);

                }
            

        }
    }

    public enum Search { 
        BEFORELINE,
        AFTERLINE  
    }

        public static class ParserRules
        {

            public static string COMPILATIONUNIT = "compilationUnit";

            public static string PACKAGEDECLARATION = "packageDeclaration";

            public static string IMPORTDECLARATION = "importDeclaration";

            public static string TYPEDECLARATION = "typeDeclaration";

            public static string MODIFIER = "modifier";

            public static string CLASSORINTERFACEMODIFIER = "classOrInterfaceModifier";

            public static string VARIABLEMODIFIER = "variableModifier";

            public static string CLASSDECLARATION = "classDeclaration";

            public static string TYPEPARAMETERS = "typeParameters";

            public static string TYPEPARAMETER = "typeParameter";

            public static string TYPEBOUND = "typeBound";

            public static string ENUMDECLARATION = "enumDeclaration";

            public static string ENUMCONSTANTS = "enumConstants";

            public static string ENUMCONSTANT = "enumConstant";

            public static string ENUMBODYDECLARATIONS = "enumBodyDeclarations";

            public static string INTERFACEDECLARATION = "interfaceDeclaration";

            public static string CLASSBODY = "classBody";

            public static string INTERFACEBODY = "interfaceBody";

            public static string CLASSBODYDECLARATION = "classBodyDeclaration";

            public static string MEMBERDECLARATION = "memberDeclaration";

            public static string METHODDECLARATION = "methodDeclaration";

            public static string METHODBODY = "methodBody";

            public static string TYPETYPEORVOID = "typeTypeOrVoid";

            public static string GENERICMETHODDECLARATION = "genericMethodDeclaration";

            public static string GENERICCONSTRUCTORDECLARATION = "genericConstructorDeclaration";

            public static string CONSTRUCTORDECLARATION = "constructorDeclaration";

            public static string FIELDDECLARATION = "fieldDeclaration";

            public static string INTERFACEBODYDECLARATION = "interfaceBodyDeclaration";

            public static string INTERFACEMEMBERDECLARATION = "interfaceMemberDeclaration";

            public static string CONSTDECLARATION = "constDeclaration";

            public static string CONSTANTDECLARATOR = "constantDeclarator";

            public static string INTERFACEMETHODDECLARATION = "interfaceMethodDeclaration";

            public static string INTERFACEMETHODMODIFIER = "interfaceMethodModifier";

            public static string GENERICINTERFACEMETHODDECLARATION = "genericInterfaceMethodDeclaration";

            public static string VARIABLEDECLARATORS = "variableDeclarators";

            public static string VARIABLEDECLARATOR = "variableDeclarator";

            public static string VARIABLEDECLARATORID = "variableDeclaratorId";

            public static string VARIABLEINITIALIZER = "variableInitializer";

            public static string ARRAYINITIALIZER = "arrayInitializer";

            public static string CLASSORINTERFACETYPE = "classOrInterfaceType";

            public static string TYPEARGUMENT = "typeArgument";

            public static string QUALIFIEDNAMELIST = "qualifiedNameList";

            public static string FORMALPARAMETERS = "formalParameters";

            public static string FORMALPARAMETERLIST = "formalParameterList";

            public static string FORMALPARAMETER = "formalParameter";

            public static string LASTFORMALPARAMETER = "lastFormalParameter";

            public static string QUALIFIEDNAME = "qualifiedName";

            public static string LITERAL = "literal";

            public static string INTEGERLITERAL = "integerLiteral";

            public static string FLOATLITERAL = "floatLiteral";

            public static string ANNOTATION = "annotation";

            public static string ELEMENTVALUEPAIRS = "elementValuePairs";

            public static string ELEMENTVALUEPAIR = "elementValuePair";

            public static string ELEMENTVALUE = "elementValue";

            public static string ELEMENTVALUEARRAYINITIALIZER = "elementValueArrayInitializer";

            public static string ANNOTATIONTYPEDECLARATION = "annotationTypeDeclaration";

            public static string ANNOTATIONTYPEBODY = "annotationTypeBody";

            public static string ANNOTATIONTYPEELEMENTDECLARATION = "annotationTypeElementDeclaration";

            public static string ANNOTATIONTYPEELEMENTREST = "annotationTypeElementRest";

            public static string ANNOTATIONMETHODORCONSTANTREST = "annotationMethodOrConstantRest";

            public static string ANNOTATIONMETHODREST = "annotationMethodRest";

            public static string ANNOTATIONCONSTANTREST = "annotationConstantRest";

            public static string DEFAULTVALUE = "defaultValue";

            public static string BLOCK = "block";

            public static string BLOCKSTATEMENT = "blockStatement";

            public static string LOCALVARIABLEDECLARATION = "localVariableDeclaration";

            public static string LOCALTYPEDECLARATION = "localTypeDeclaration";

            public static string STATEMENT = "statement";

            public static string CATCHCLAUSE = "catchClause";

            public static string CATCHTYPE = "catchType";

            public static string FINALLYBLOCK = "finallyBlock";

            public static string RESOURCESPECIFICATION = "resourceSpecification";

            public static string RESOURCES = "resources";

            public static string RESOURCE = "resource";

            public static string SWITCHBLOCKSTATEMENTGROUP = "switchBlockStatementGroup";

            public static string SWITCHLABEL = "switchLabel";

            public static string FORCONTROL = "forControl";

            public static string FORINIT = "forInit";

            public static string ENHANCEDFORCONTROL = "enhancedForControl";

            public static string PAREXPRESSION = "parExpression";

            public static string EXPRESSIONLIST = "expressionList";

            public static string METHODCALL = "methodCall";

            public static string EXPRESSION = "expression";

            public static string LAMBDAEXPRESSION = "lambdaExpression";

            public static string LAMBDAPARAMETERS = "lambdaParameters";

            public static string LAMBDABODY = "lambdaBody";

            public static string PRIMARY = "primary";

            public static string CLASSTYPE = "classType";

            public static string CREATOR = "creator";

            public static string CREATEDNAME = "createdName";

            public static string INNERCREATOR = "innerCreator";

            public static string ARRAYCREATORREST = "arrayCreatorRest";

            public static string CLASSCREATORREST = "classCreatorRest";

            public static string EXPLICITGENERICINVOCATION = "explicitGenericInvocation";

            public static string TYPEARGUMENTSORDIAMOND = "typeArgumentsOrDiamond";

            public static string NONWILDCARDTYPEARGUMENTSORDIAMOND = "nonWildcardTypeArgumentsOrDiamond";

            public static string NONWILDCARDTYPEARGUMENTS = "nonWildcardTypeArguments";

            public static string TYPELIST = "typeList";

            public static string TYPETYPE = "typeType";

            public static string PRIMITIVETYPE = "primitiveType";

            public static string TYPEARGUMENTS = "typeArguments";

            public static string SUPERSUFFIX = "superSuffix";

            public static string EXPLICITGENERICINVOCATIONSUFFIX = "explicitGenericInvocationSuffix";

            public static string ARGUMENTS = "arguments";


        }

}

