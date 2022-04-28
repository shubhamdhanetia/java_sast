using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using netcorejavast.AST.Models;
using netcorejavast.AST.Processor;
using netcorejavast.AST.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace netcorejavast
{
    public class Scanner
    {
        private List<QueryProcessor> _FileVulnerabilities;

        IDictionary<string, IQuery> files;

        private ScannerType _scannerType;
        public string Filepath { get; set; }

        private IQuery _scanner;
        public Scanner(ScannerType scannerType) {

            _scannerType = scannerType;
            files = new Dictionary<string, IQuery>();
            _FileVulnerabilities = new List<QueryProcessor>();
        }

        public List<QueryProcessor> GetFileVulnerabilityList() {
            return _FileVulnerabilities;
        }

        public void run() {

            switch (_scannerType) {

                case ScannerType.AllVulnerabilityCheck:
                    files.Add(Filepath + "DirectoryTraversalVulnerability", new DirectoryTraversalAttackScanner());
                    files.Add(Filepath + "EmptyTryCatchVulnerability", new EmptyTryCatchScanner());
                    files.Add(Filepath + "SecureCookieVulnerability", new SecureCookieFlag());
                    files.Add(Filepath + "SecureCookieVulnerabilityXML", new SecureCookieFlagWebXML());
                    files.Add(Filepath + "LDAPInjectionVulnerability", new LdapInjectionScanner());
                    break;
                case ScannerType.DirectoryTraversalVulnerability:
                    files.Add(Filepath + "DirectoryTraversalVulnerability", new DirectoryTraversalAttackScanner());
                    break;
                case ScannerType.EmptyTryCatchVulnerability:
                    files.Add(Filepath + "EmptyTryCatchVulnerability", new EmptyTryCatchScanner());
                    break;
                case ScannerType.SecureCookieVulnerability:
                    files.Add(Filepath + "SecureCookieVulnerability", new SecureCookieFlag());
                    break;
                case ScannerType.SecureCookieVulnerabilityXML:
                    files.Add(Filepath + "SecureCookieVulnerabilityXML", new SecureCookieFlagWebXML());
                    break;
                case ScannerType.LdapInjectionVulnerability:
                    files.Add(Filepath + "LDAPInjectionVulnerability", new LdapInjectionScanner());
                    break;
            }
            foreach (KeyValuePair<string, IQuery> kvp in files) {
                _scanner = kvp.Value;
                DirectoryScan(kvp.Key);
            }

            printResults(_FileVulnerabilities);
        }

        private void DirectoryScan(string folder_path) {

            
            foreach (string file in Directory.GetFiles(folder_path))
            {
                AntlrFileStream stream = new AntlrFileStream(file);
                ITokenSource lexer = new JavaLexer(stream);
                ITokenStream tokens = new CommonTokenStream(lexer);
                JavaParser parser = new JavaParser(tokens);
                parser.BuildParseTree = true;
                IParseTree parseTree = parser.compilationUnit();
                RootASTNode rootAstNode = new RootASTNode();
                rootAstNode.StartProcessingTree(parseTree, parser.RuleNames.ToList());
                JavaParserHelper.rules = rootAstNode.rules;
                JavaParserHelper.AstForAllRules = rootAstNode.AstForAllRules;
                QueryProcessor queryProcessor = new QueryProcessor();
                JavaParserHelper.current_file = file;
                queryProcessor.FileName = file;
                queryProcessor.AddScanner(_scanner);
                queryProcessor.Start();
                _FileVulnerabilities.Add(queryProcessor);
            }
            foreach (string subDirectory in Directory.GetDirectories(folder_path))
            {
                DirectoryScan(subDirectory);
            }
        }

        private void printResults(List<QueryProcessor> queryprocessorList)
        {
            foreach (var obj in queryprocessorList)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Findings for the file {0}", obj.FileName);
                Console.WriteLine("----------------------------------------");
                foreach (var finding in obj.GetFindings())
                {
                    Console.WriteLine("Line Number : {0}", finding.LineNumber);
                    Console.WriteLine("Affected Line Code : {0}", finding.AffectedLineCode);
                    Console.WriteLine("Reason : {0}", finding.Reason);
                    Console.WriteLine("Severity : {0}", finding.Severity.ToString());
                    Console.WriteLine();
                }
            }
        }

    }
    public enum ScannerType
    {
        DirectoryTraversalVulnerability,
        EmptyTryCatchVulnerability,
        SecureCookieVulnerability,
        SecureCookieVulnerabilityXML,
        AllVulnerabilityCheck,
        LdapInjectionVulnerability
    }
}
