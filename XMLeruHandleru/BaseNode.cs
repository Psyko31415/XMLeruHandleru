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
        public abstract BaseNode GetChild(int i);
        public abstract int GetChildCount();
        public abstract List<BaseNode> GetCssLike(string query);
        public abstract string ToXml(int indent = 0);
        public abstract void GetCssLikeRec(string[] rules, ref List<BaseNode> res);
        public abstract bool RulesMatches(string[] rules, int i);
    }
}
