using netcorejavast.AST.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcorejavast.AST.Queries
{
    public interface IQuery
    {
        List<QueryFinding> processRequest();
        
    }
}
