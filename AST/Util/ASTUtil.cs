using System;
using System.Text;
namespace netcorejavast
{
    [System.CLSCompliant(false)]
    public class ASTUtil
    {
        private static StringBuilder stringBuilder = new StringBuilder();
        public static void PrintASTNodes(ASTnode node,JavaParser parser)
        {
            // if(node.RuleIndex>=0)
            //     Console.WriteLine(parser.RuleNames[node.RuleIndex]);
            for(int i=0;i<node.Children.Count;i++)
            {
                PrintASTNodes(node.Children[i],parser);
            }
        }

        public static void PrintAST(ASTnode node)
        {
            if(node!=null)
            {
                Console.WriteLine(node.Text);
            }
            
            for(int i=0;i<node.Children.Count;i++)
            {
                PrintAST(node.Children[i]);
            }
        }

        public static string ASTtoString(ASTnode node)
        {
            ASTUtil.stringBuilder.Clear();
            ASTtoStringRecur(node);
            return ASTUtil.stringBuilder.ToString();
        }
        
        private static void ASTtoStringRecur(ASTnode node){
            if(node==null){
                return;
            }
            ASTUtil.stringBuilder.AppendLine(node.Text);
            for(int i=0;i<node.Children.Count;i++)
            {
                ASTtoStringRecur(node.Children[i]);
            }
        }
    }
}