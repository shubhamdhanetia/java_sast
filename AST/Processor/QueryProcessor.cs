using netcorejavast.AST.Models;
using netcorejavast.AST.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace netcorejavast.AST.Processor
{
    public class QueryProcessor
    {
        public string FileName { get; set; }
        private List<IQuery> _scanners;
        private List<QueryFinding> _findings;

        public QueryProcessor() {
            _scanners = new List<IQuery>();
            _findings = new List<QueryFinding>();
        }

        public void AddScannerList(List<IQuery> scanner) {
            _scanners.AddRange(scanner);
        }

        public void AddScanner(IQuery scanner) {
            _scanners.Add(scanner);
        }

        public void Start() {
            foreach (var obj in _scanners) {
                _findings.AddRange(obj.processRequest());        
            }
            foreach (var finding in _findings) { 
            finding.AffectedLineCode = File.ReadLines(FileName).Skip(finding.LineNumber-1).Take(1).First();
            }
        }

        public void AddFinding(QueryFinding finding) {
            _findings.Add(finding);
        }
        public List<QueryFinding> GetFindings() {
            return _findings; 
        }

    }
}
