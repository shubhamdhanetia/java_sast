using System;
using System.Collections.Generic;
using System.Text;

namespace netcorejavast.AST.Models
{
    public class QueryFinding { 
    
        public string Reason { get; set; }
        public int LineNumber { get; set; }
        public string AffectedLineCode { get; set; }

        public Severity Severity { get; set; } 
    
    }

    public enum Severity { 
        Informational,
        Low,
        Medium,
        High,
        Critical
    }
}
