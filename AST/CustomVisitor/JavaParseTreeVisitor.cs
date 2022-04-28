using System;
using System.Diagnostics.CodeAnalysis;
using Antlr4.Runtime.Tree;

namespace netcorejavast
{
    [System.CLSCompliant(false)]
    public class JavaParseTreeVisitor : JavaParserBaseVisitor<object>
    {
       

        public override object Visit(IParseTree tree)
        { 
            
            return base.Visit(tree);
        }

        public override object VisitAnnotation([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationContext context)
        {
            return base.VisitAnnotation(context);
        }

        public override object VisitAnnotationConstantRest([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationConstantRestContext context)
        {
            return base.VisitAnnotationConstantRest(context);
        }

        public override object VisitAnnotationMethodOrConstantRest([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationMethodOrConstantRestContext context)
        {
            return base.VisitAnnotationMethodOrConstantRest(context);
        }

        public override object VisitAnnotationMethodRest([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationMethodRestContext context)
        {
            return base.VisitAnnotationMethodRest(context);
        }

        public override object VisitAnnotationTypeBody([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationTypeBodyContext context)
        {
            return base.VisitAnnotationTypeBody(context);
        }

        public override object VisitAnnotationTypeDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationTypeDeclarationContext context)
        {
            return base.VisitAnnotationTypeDeclaration(context);
        }

        public override object VisitAnnotationTypeElementDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationTypeElementDeclarationContext context)
        {
            return base.VisitAnnotationTypeElementDeclaration(context);
        }

        public override object VisitAnnotationTypeElementRest([Antlr4.Runtime.Misc.NotNull] JavaParser.AnnotationTypeElementRestContext context)
        {
            return base.VisitAnnotationTypeElementRest(context);
        }

        public override object VisitArguments([Antlr4.Runtime.Misc.NotNull] JavaParser.ArgumentsContext context)
        {
            return base.VisitArguments(context);
        }

        public override object VisitArrayCreatorRest([Antlr4.Runtime.Misc.NotNull] JavaParser.ArrayCreatorRestContext context)
        {
            return base.VisitArrayCreatorRest(context);
        }

        public override object VisitArrayInitializer([Antlr4.Runtime.Misc.NotNull] JavaParser.ArrayInitializerContext context)
        {
            return base.VisitArrayInitializer(context);
        }

        public override object VisitBlock([Antlr4.Runtime.Misc.NotNull] JavaParser.BlockContext context)
        {
            return base.VisitBlock(context);
        }

        public override object VisitBlockStatement([Antlr4.Runtime.Misc.NotNull] JavaParser.BlockStatementContext context)
        {
            return base.VisitBlockStatement(context);
        }

        public override object VisitCatchClause([Antlr4.Runtime.Misc.NotNull] JavaParser.CatchClauseContext context)
        {
            return base.VisitCatchClause(context);
        }

        public override object VisitCatchType([Antlr4.Runtime.Misc.NotNull] JavaParser.CatchTypeContext context)
        {
            return base.VisitCatchType(context);
        }

        public override object VisitChildren(IRuleNode node)
        {
            Console.WriteLine("Parse Tree parse visit Children");
            return base.VisitChildren(node);
        }

        public override object VisitClassBody([Antlr4.Runtime.Misc.NotNull] JavaParser.ClassBodyContext context)
        {
            return base.VisitClassBody(context);
        }

        public override object VisitClassBodyDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.ClassBodyDeclarationContext context)
        {
            return base.VisitClassBodyDeclaration(context);
        }

        public override object VisitClassCreatorRest([Antlr4.Runtime.Misc.NotNull] JavaParser.ClassCreatorRestContext context)
        {
            return base.VisitClassCreatorRest(context);
        }

        public override object VisitClassDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.ClassDeclarationContext context)
        {
            return base.VisitClassDeclaration(context);
        }

        public override object VisitClassOrInterfaceModifier([Antlr4.Runtime.Misc.NotNull] JavaParser.ClassOrInterfaceModifierContext context)
        {
            return base.VisitClassOrInterfaceModifier(context);
        }

        public override object VisitClassOrInterfaceType([Antlr4.Runtime.Misc.NotNull] JavaParser.ClassOrInterfaceTypeContext context)
        {
            return base.VisitClassOrInterfaceType(context);
        }

        public override object VisitClassType([Antlr4.Runtime.Misc.NotNull] JavaParser.ClassTypeContext context)
        {
            return base.VisitClassType(context);
        }

        public override object VisitCompilationUnit([Antlr4.Runtime.Misc.NotNull] JavaParser.CompilationUnitContext context)
        {
            return base.VisitCompilationUnit(context);
        }

        public override object VisitConstantDeclarator([Antlr4.Runtime.Misc.NotNull] JavaParser.ConstantDeclaratorContext context)
        {
            return base.VisitConstantDeclarator(context);
        }

        public override object VisitConstDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.ConstDeclarationContext context)
        {
            return base.VisitConstDeclaration(context);
        }

        public override object VisitConstructorDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.ConstructorDeclarationContext context)
        {
            return base.VisitConstructorDeclaration(context);
        }

        public override object VisitCreatedName([Antlr4.Runtime.Misc.NotNull] JavaParser.CreatedNameContext context)
        {
            return base.VisitCreatedName(context);
        }

        public override object VisitCreator([Antlr4.Runtime.Misc.NotNull] JavaParser.CreatorContext context)
        {
            return base.VisitCreator(context);
        }

        public override object VisitDefaultValue([Antlr4.Runtime.Misc.NotNull] JavaParser.DefaultValueContext context)
        {
            return base.VisitDefaultValue(context);
        }

        public override object VisitElementValue([Antlr4.Runtime.Misc.NotNull] JavaParser.ElementValueContext context)
        {
            return base.VisitElementValue(context);
        }

        public override object VisitElementValueArrayInitializer([Antlr4.Runtime.Misc.NotNull] JavaParser.ElementValueArrayInitializerContext context)
        {
            return base.VisitElementValueArrayInitializer(context);
        }

        public override object VisitElementValuePair([Antlr4.Runtime.Misc.NotNull] JavaParser.ElementValuePairContext context)
        {
            return base.VisitElementValuePair(context);
        }

        public override object VisitElementValuePairs([Antlr4.Runtime.Misc.NotNull] JavaParser.ElementValuePairsContext context)
        {
            return base.VisitElementValuePairs(context);
        }

        public override object VisitEnhancedForControl([Antlr4.Runtime.Misc.NotNull] JavaParser.EnhancedForControlContext context)
        {
            return base.VisitEnhancedForControl(context);
        }

        public override object VisitEnumBodyDeclarations([Antlr4.Runtime.Misc.NotNull] JavaParser.EnumBodyDeclarationsContext context)
        {
            return base.VisitEnumBodyDeclarations(context);
        }

        public override object VisitEnumConstant([Antlr4.Runtime.Misc.NotNull] JavaParser.EnumConstantContext context)
        {
            return base.VisitEnumConstant(context);
        }

        public override object VisitEnumConstants([Antlr4.Runtime.Misc.NotNull] JavaParser.EnumConstantsContext context)
        {
            return base.VisitEnumConstants(context);
        }

        public override object VisitEnumDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.EnumDeclarationContext context)
        {
            return base.VisitEnumDeclaration(context);
        }

        public override object VisitErrorNode(IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }

        public override object VisitExplicitGenericInvocation([Antlr4.Runtime.Misc.NotNull] JavaParser.ExplicitGenericInvocationContext context)
        {
            return base.VisitExplicitGenericInvocation(context);
        }

        public override object VisitExplicitGenericInvocationSuffix([Antlr4.Runtime.Misc.NotNull] JavaParser.ExplicitGenericInvocationSuffixContext context)
        {
            return base.VisitExplicitGenericInvocationSuffix(context);
        }

        public override object VisitExpression([Antlr4.Runtime.Misc.NotNull] JavaParser.ExpressionContext context)
        {
            return base.VisitExpression(context);
        }

        public override object VisitExpressionList([Antlr4.Runtime.Misc.NotNull] JavaParser.ExpressionListContext context)
        {
            return base.VisitExpressionList(context);
        }

        public override object VisitFieldDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.FieldDeclarationContext context)
        {
            return base.VisitFieldDeclaration(context);
        }

        public override object VisitFinallyBlock([Antlr4.Runtime.Misc.NotNull] JavaParser.FinallyBlockContext context)
        {
            return base.VisitFinallyBlock(context);
        }

        public override object VisitFloatLiteral([Antlr4.Runtime.Misc.NotNull] JavaParser.FloatLiteralContext context)
        {
            return base.VisitFloatLiteral(context);
        }

        public override object VisitForControl([Antlr4.Runtime.Misc.NotNull] JavaParser.ForControlContext context)
        {
            return base.VisitForControl(context);
        }

        public override object VisitForInit([Antlr4.Runtime.Misc.NotNull] JavaParser.ForInitContext context)
        {
            return base.VisitForInit(context);
        }

        public override object VisitFormalParameter([Antlr4.Runtime.Misc.NotNull] JavaParser.FormalParameterContext context)
        {
            return base.VisitFormalParameter(context);
        }

        public override object VisitFormalParameterList([Antlr4.Runtime.Misc.NotNull] JavaParser.FormalParameterListContext context)
        {
            return base.VisitFormalParameterList(context);
        }

        public override object VisitFormalParameters([Antlr4.Runtime.Misc.NotNull] JavaParser.FormalParametersContext context)
        {
            return base.VisitFormalParameters(context);
        }

        public override object VisitGenericConstructorDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.GenericConstructorDeclarationContext context)
        {
            return base.VisitGenericConstructorDeclaration(context);
        }

        public override object VisitGenericInterfaceMethodDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.GenericInterfaceMethodDeclarationContext context)
        {
            return base.VisitGenericInterfaceMethodDeclaration(context);
        }

        public override object VisitGenericMethodDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.GenericMethodDeclarationContext context)
        {
            return base.VisitGenericMethodDeclaration(context);
        }

        public override object VisitImportDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.ImportDeclarationContext context)
        {
            return base.VisitImportDeclaration(context);
        }

        public override object VisitInnerCreator([Antlr4.Runtime.Misc.NotNull] JavaParser.InnerCreatorContext context)
        {
            return base.VisitInnerCreator(context);
        }

        public override object VisitIntegerLiteral([Antlr4.Runtime.Misc.NotNull] JavaParser.IntegerLiteralContext context)
        {
            return base.VisitIntegerLiteral(context);
        }

        public override object VisitInterfaceBody([Antlr4.Runtime.Misc.NotNull] JavaParser.InterfaceBodyContext context)
        {
            return base.VisitInterfaceBody(context);
        }

        public override object VisitInterfaceBodyDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.InterfaceBodyDeclarationContext context)
        {
            return base.VisitInterfaceBodyDeclaration(context);
        }

        public override object VisitInterfaceDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.InterfaceDeclarationContext context)
        {
            return base.VisitInterfaceDeclaration(context);
        }

        public override object VisitInterfaceMemberDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.InterfaceMemberDeclarationContext context)
        {
            return base.VisitInterfaceMemberDeclaration(context);
        }

        public override object VisitInterfaceMethodDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.InterfaceMethodDeclarationContext context)
        {
            return base.VisitInterfaceMethodDeclaration(context);
        }

        public override object VisitInterfaceMethodModifier([Antlr4.Runtime.Misc.NotNull] JavaParser.InterfaceMethodModifierContext context)
        {
            return base.VisitInterfaceMethodModifier(context);
        }

        public override object VisitLambdaBody([Antlr4.Runtime.Misc.NotNull] JavaParser.LambdaBodyContext context)
        {
            return base.VisitLambdaBody(context);
        }

        public override object VisitLambdaExpression([Antlr4.Runtime.Misc.NotNull] JavaParser.LambdaExpressionContext context)
        {
            return base.VisitLambdaExpression(context);
        }

        public override object VisitLambdaParameters([Antlr4.Runtime.Misc.NotNull] JavaParser.LambdaParametersContext context)
        {
            return base.VisitLambdaParameters(context);
        }

        public override object VisitLastFormalParameter([Antlr4.Runtime.Misc.NotNull] JavaParser.LastFormalParameterContext context)
        {
            return base.VisitLastFormalParameter(context);
        }

        public override object VisitLiteral([Antlr4.Runtime.Misc.NotNull] JavaParser.LiteralContext context)
        {
            return base.VisitLiteral(context);
        }

        public override object VisitLocalTypeDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.LocalTypeDeclarationContext context)
        {
            return base.VisitLocalTypeDeclaration(context);
        }

        public override object VisitLocalVariableDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.LocalVariableDeclarationContext context)
        {
            return base.VisitLocalVariableDeclaration(context);
        }

        public override object VisitMemberDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.MemberDeclarationContext context)
        {
            return base.VisitMemberDeclaration(context);
        }

        public override object VisitMethodBody([Antlr4.Runtime.Misc.NotNull] JavaParser.MethodBodyContext context)
        {
            return base.VisitMethodBody(context);
        }

        public override object VisitMethodCall([Antlr4.Runtime.Misc.NotNull] JavaParser.MethodCallContext context)
        {
            return base.VisitMethodCall(context);
        }

        public override object VisitMethodDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.MethodDeclarationContext context)
        {
            return base.VisitMethodDeclaration(context);
        }

        public override object VisitModifier([Antlr4.Runtime.Misc.NotNull] JavaParser.ModifierContext context)
        {
            return base.VisitModifier(context);
        }

        public override object VisitNonWildcardTypeArguments([Antlr4.Runtime.Misc.NotNull] JavaParser.NonWildcardTypeArgumentsContext context)
        {
            return base.VisitNonWildcardTypeArguments(context);
        }

        public override object VisitNonWildcardTypeArgumentsOrDiamond([Antlr4.Runtime.Misc.NotNull] JavaParser.NonWildcardTypeArgumentsOrDiamondContext context)
        {
            return base.VisitNonWildcardTypeArgumentsOrDiamond(context);
        }

        public override object VisitPackageDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.PackageDeclarationContext context)
        {
            return base.VisitPackageDeclaration(context);
        }

        public override object VisitParExpression([Antlr4.Runtime.Misc.NotNull] JavaParser.ParExpressionContext context)
        {
            return base.VisitParExpression(context);
        }

        public override object VisitPrimary([Antlr4.Runtime.Misc.NotNull] JavaParser.PrimaryContext context)
        {
            return base.VisitPrimary(context);
        }

        public override object VisitPrimitiveType([Antlr4.Runtime.Misc.NotNull] JavaParser.PrimitiveTypeContext context)
        {
            return base.VisitPrimitiveType(context);
        }

        public override object VisitQualifiedName([Antlr4.Runtime.Misc.NotNull] JavaParser.QualifiedNameContext context)
        {
            return base.VisitQualifiedName(context);
        }

        public override object VisitQualifiedNameList([Antlr4.Runtime.Misc.NotNull] JavaParser.QualifiedNameListContext context)
        {
            return base.VisitQualifiedNameList(context);
        }

        public override object VisitResource([Antlr4.Runtime.Misc.NotNull] JavaParser.ResourceContext context)
        {
            return base.VisitResource(context);
        }

        public override object VisitResources([Antlr4.Runtime.Misc.NotNull] JavaParser.ResourcesContext context)
        {
            return base.VisitResources(context);
        }

        public override object VisitResourceSpecification([Antlr4.Runtime.Misc.NotNull] JavaParser.ResourceSpecificationContext context)
        {
            return base.VisitResourceSpecification(context);
        }

        public override object VisitStatement([Antlr4.Runtime.Misc.NotNull] JavaParser.StatementContext context)
        {
            return base.VisitStatement(context);
        }

        public override object VisitSuperSuffix([Antlr4.Runtime.Misc.NotNull] JavaParser.SuperSuffixContext context)
        {
            return base.VisitSuperSuffix(context);
        }

        public override object VisitSwitchBlockStatementGroup([Antlr4.Runtime.Misc.NotNull] JavaParser.SwitchBlockStatementGroupContext context)
        {
            return base.VisitSwitchBlockStatementGroup(context);
        }

        public override object VisitSwitchLabel([Antlr4.Runtime.Misc.NotNull] JavaParser.SwitchLabelContext context)
        {
            return base.VisitSwitchLabel(context);
        }

        public override object VisitTerminal(ITerminalNode node)
        {
            return base.VisitTerminal(node);
        }

        public override object VisitTypeArgument([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeArgumentContext context)
        {
            return base.VisitTypeArgument(context);
        }

        public override object VisitTypeArguments([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeArgumentsContext context)
        {
            return base.VisitTypeArguments(context);
        }

        public override object VisitTypeArgumentsOrDiamond([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeArgumentsOrDiamondContext context)
        {
            return base.VisitTypeArgumentsOrDiamond(context);
        }

        public override object VisitTypeBound([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeBoundContext context)
        {
            return base.VisitTypeBound(context);
        }

        public override object VisitTypeDeclaration([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeDeclarationContext context)
        {
            return base.VisitTypeDeclaration(context);
        }

        public override object VisitTypeList([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeListContext context)
        {
            return base.VisitTypeList(context);
        }

        public override object VisitTypeParameter([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeParameterContext context)
        {
            return base.VisitTypeParameter(context);
        }

        public override object VisitTypeParameters([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeParametersContext context)
        {
            return base.VisitTypeParameters(context);
        }

        public override object VisitTypeType([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeTypeContext context)
        {
            return base.VisitTypeType(context);
        }

        public override object VisitTypeTypeOrVoid([Antlr4.Runtime.Misc.NotNull] JavaParser.TypeTypeOrVoidContext context)
        {
            return base.VisitTypeTypeOrVoid(context);
        }

        public override object VisitVariableDeclarator([Antlr4.Runtime.Misc.NotNull] JavaParser.VariableDeclaratorContext context)
        {
            return base.VisitVariableDeclarator(context);
        }

        public override object VisitVariableDeclaratorId([Antlr4.Runtime.Misc.NotNull] JavaParser.VariableDeclaratorIdContext context)
        {
            return base.VisitVariableDeclaratorId(context);
        }

        public override object VisitVariableDeclarators([Antlr4.Runtime.Misc.NotNull] JavaParser.VariableDeclaratorsContext context)
        {
            return base.VisitVariableDeclarators(context);
        }

        public override object VisitVariableInitializer([Antlr4.Runtime.Misc.NotNull] JavaParser.VariableInitializerContext context)
        {
            return base.VisitVariableInitializer(context);
        }

        public override object VisitVariableModifier([Antlr4.Runtime.Misc.NotNull] JavaParser.VariableModifierContext context)
        {
            return base.VisitVariableModifier(context);
        }

        protected override object AggregateResult(object aggregate, object nextResult)
        {
            return base.AggregateResult(aggregate, nextResult);
        }

        protected override bool ShouldVisitNextChild(IRuleNode node, object currentResult)
        {
            return base.ShouldVisitNextChild(node, currentResult);
        }
    }
}