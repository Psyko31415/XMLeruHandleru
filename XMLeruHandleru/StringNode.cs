using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    class StringNode : BaseNode
    {
        public StringNode(string name, Node parent)
        {
            Name = name;
            Parent = parent;
        }

        public override BaseNode AddNode(string name)
        {
            return Parent.AddNode(name);
        }

        public override BaseNode AddNode(Node n)
        {
            return Parent.AddNode(n);
        }

        public override BaseNode AddString(string s)
        {
            return Parent.AddString(s);
        }


        public override void AddAttr(string k, string v)
        {
            Parent.AddAttr(k, v);
        }

        public override string ToString()
        {
            return Name;
        }

        public override BaseNode getChild(int i)
        {
            return Parent.getChild(i);
        }

        public override int getChildCount()
        {
            return Parent.getChildCount();
        }

        public override List<BaseNode> GetCssLike(string xpath)
        {
            return Parent.GetCssLike(xpath);
        }
    }
}
