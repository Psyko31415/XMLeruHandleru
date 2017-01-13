using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    abstract class BaseNode
    {
        protected BaseNode Parent { get; set; }
        public string Name { get; protected set; }

        public abstract BaseNode AddNode(string name);
        public abstract BaseNode AddString(string s);
        public abstract BaseNode AddChild(BaseNode n);
        public abstract void AddAttr(string k, string v);
        public abstract BaseNode getChild(int i);
        public abstract int getChildCount();
        public abstract List<BaseNode> GetCssLike(string query);
        public abstract string ToXml(int indent = 0);
    }
}
