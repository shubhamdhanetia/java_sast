using System;
using Antlr4.Runtime.Tree;

namespace netcorejavast
{
    public class ParseTreeUtil
    {
        public static void PrintTree(IParseTree node)
        {
            Console.WriteLine(node.GetText());
            for(int i=0;i<node.ChildCount;i++)
            {
                PrintTree(node.GetChild(i));
            }
        }

        public static void PrintChildrenWithTypeInfo(IParseTree node)
        {

            for(int i=0;i<node.ChildCount;i++)
            {
                Console.WriteLine(i + ") " +node.GetChild(i).GetText() + " ==> " +node.GetChild(i).GetType().ToString());
            }
        }
    }
}