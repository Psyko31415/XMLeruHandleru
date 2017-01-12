using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    abstract class BaseNode
    {
        protected Node Parent { get; set; }
        public string Name { get; protected set; }

        public abstract BaseNode AddNode(string name);
        public abstract BaseNode AddNode(Node n);
        public abstract BaseNode AddString(string s);
        public abstract void AddAttr(string k, string v);
        public abstract override string ToString();
        public abstract BaseNode getChild(int i);
        public abstract int getChildCount();
        public abstract List<BaseNode> GetCssLike(string query);
    }
}
