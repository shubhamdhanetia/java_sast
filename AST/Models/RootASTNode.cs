using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using netcorejavast.AST.Processor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace netcorejavast.AST.Models
{
    public class RootASTNode
    {
        public List<string> rules { get; set; }

        public Dictionary<string,List<IParseTree>> AstForAllRules { get; set; }

        public string GetRuleName(IParseTree node)
        {
            string rule = null;
            try
            {
                rule = this.rules[((ParserRuleContext)node).RuleIndex];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rule;
        }

        public RootASTNode() {
            rules = new List<string>();
            AstForAllRules = new Dictionary<string, List<IParseTree>>();
        }

        public void StartProcessingTree(IParseTree root,List<string> rules) {
            this.rules = rules;
            foreach (string str in rules) {
                this.AstForAllRules.Add(str, new List<IParseTree>());
            }
            generateAST(root);           
        }

        public void generateAST(IParseTree node) {

            if (node.ChildCount == 0)
            {
                return;
            }
            AstForAllRules[GetRuleName(node)].Add(node);

            for (int j = 0; j < node.ChildCount; j++)
            {
                generateAST(node.GetChild(j));

            }

        }

 

    }
}
