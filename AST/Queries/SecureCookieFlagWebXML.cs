using netcorejavast.AST.Models;
using netcorejavast.AST.Processor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace netcorejavast.AST.Queries
{
    public class SecureCookieFlagWebXML : IQuery
    {
        private List<QueryFinding> _listoffindings { get; set; }
        private XmlDocument doc { get; set; }
        XElement rootElement { get; set; }

        public List<QueryFinding> processRequest()
        {
            _listoffindings = new List<QueryFinding>();
            doc = new XmlDocument();
            QueryFinding queryFinding = new QueryFinding();
            doc.Load(JavaParserHelper.current_file);
            try
            {
                bool check_httponly = false;
                bool check_secure = false;
                XmlNodeList elemList = doc.GetElementsByTagName("cookie-config");
                if (elemList.Count > 0)
                {
                    var cookie_node = elemList.Item(0);
                    if (cookie_node.HasChildNodes)
                    {
                        foreach (XmlElement childnode in cookie_node)
                        {

                            if (childnode.Name == "http-only" && childnode.InnerText == "true")
                            {
                                check_httponly = true;
                            }
                            else if (childnode.Name == "secure" && childnode.InnerText == "true")
                            {
                                check_secure = true;
                            }

                        }
                        if (check_httponly == true && check_secure == true)
                        {
                            return _listoffindings; //No Finding. Return Empty list
                        }

                    }                   
                    //queryFinding.LineNumber = ((IXmlLineInfo)cookie_node).LineNumber;
                    queryFinding.Reason = "Cookies are not secured in <cookie-config> configuration ";
                    queryFinding.Severity = Severity.High;
                    _listoffindings.Add(queryFinding);

                }
              
            }
            catch (Exception ex) {
                
            }

            
            return _listoffindings;

        }

    }
}
