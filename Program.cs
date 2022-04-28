using System;
using System.IO;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using netcorejavast.AST.Models;
using System.Linq;
using netcorejavast.AST.Processor;
using netcorejavast.AST.Queries;
using System.Reflection;


[assembly: CLSCompliant(true)]
namespace netcorejavast
{
    public class Program
    {
        public static void Main(string[] args)
        {           
            Scanner scanner = new Scanner(ScannerType.SecureCookieVulnerability);
            scanner.Filepath = @"C:\Users\shubh\OneDrive\Desktop\TDC-Demo\netcorejavast\Examples\input_files\";
            scanner.run();
            var filefindings = scanner.GetFileVulnerabilityList();
        }

    }
}
