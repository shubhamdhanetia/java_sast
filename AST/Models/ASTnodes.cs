using System;
using System.Text;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using System.Collections.Generic;

namespace netcorejavast {
    public class ASTnode
    {
        public List<ASTnode> Children=new List<ASTnode>(); 
        private string _type;
        public ASTnode Parent {get; private set;}
        public string Type 
        {
            get {
                if(_type!=null)
                {
                    return _type;
                }
                return "Unknown";
                } 
            protected set {
                _type=value;
            }
        }

        private string _treeString=null;

        public string Text {private set {} get { return ToString();}}

        public string TreeText {private set{} get {return GetTreeAsString();}}
        public ASTnode(ASTnode _parent) 
        {
            Parent=_parent;
        }

         public ASTnode(ASTnode _parent,string _type) 
         {
            Type=_type;
            Parent=_parent;
        }  

        public override string ToString()
        {
            return Type;
        }

        private string GetTreeAsString(){
            if(_treeString==null)   
                _treeString = ASTUtil.ASTtoString(this);
            return _treeString;
        }
    }

    public class FileASTnode : ASTnode
    {
        private string _package;
        public List<ASTnode> imports=new List<ASTnode>();
        public List<ASTnode> classes=new List<ASTnode>();
        public List<ASTnode> interfaces=new List<ASTnode>();

        public string Package 
        {
            get {
                if (_package!=null)
                {
                    return _package;
                }
                return String.Empty;
            }
            internal set {
                _package=value;
            }
        }

        public FileASTnode(ASTnode _parent) : base( _parent)
        {
            Type="file";
        }
    }

    public class PackageASTnode : ASTnode
    {
        public string Name {get; private set;}
        public PackageASTnode( ASTnode _parent,string _name) : base( _parent)
        {
            Type="package";
            Name=_name;
        }

        public override string ToString()
        {
            return Type + " " + Name + ";";
        }
    }

    internal class ImportASTnode : ASTnode
    {
        public string PackageName {get; private set;}
        public ImportASTnode(ASTnode _parent,string _packageName) : base(_parent)
        {
            Type="import";
            PackageName=_packageName;
        }

        public override string ToString()
        {
            return Type + " " + PackageName + ";";
        }
    }

    internal class ClassASTnode : ASTnode
    {
        public string Name {get; private set;}
        public string Scope {get; private set;}

        private string[] p_implements;
        public string[] implements {get {return p_implements;} private set{}}

        public string extends {private set; get;}

        
        public ClassASTnode(ASTnode _parent,string _name,string _scope,string _extends,string[] _implements) : base(_parent)
        {
            Type="class";
            Name=_name;
            Scope=_scope;
            p_implements=_implements;
            extends=_extends;
        }

        public override string ToString()
        {
            return(Scope == "internal" ? string.Empty : Scope + " ") +  Type + " " + Name + ( extends.Equals(String.Empty) ? String.Empty : " extends " + extends) + (implements==null?string.Empty: " implements " + string.Join(',',implements));
        }
    }

  internal class MethodASTnode : ASTnode
    {
        public string Name {get; private set;}
        public string[] Modifiers {get; private set;}
        
        public MethodASTnode(ASTnode _parent,string _name,string[] _modifiers) : base(_parent)
        {
            Type="class";
            Name=_name;
            Modifiers=_modifiers;
        }

        public override string ToString()
        {
            return (Modifiers!=null? String.Join(' ',Modifiers) + " " : String.Empty) +  Name ;
        }
    }


 internal class InterfaceASTnode : ASTnode
    {
        public String Name {get; private set;}
        public String Scope {get; private set;}
       
        public InterfaceASTnode( ASTnode _parent,string name,string scope) : base(_parent)
        {
            Type="interface";
            Name=name;
            Scope=scope;
            
        }
        
        public override string ToString()
        {
            return(Scope == "internal" ? string.Empty : Scope + " ") +  Type + " " + Name;
        }

    }


}



