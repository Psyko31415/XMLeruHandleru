using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    class StringNode : BaseNode
    {
        public StringNode(string name, BaseNode parent)
        {
            Name = name;
            Parent = parent;
        }

        public override BaseNode AddNode(string name)
        {
            throw new Exception("Action not valid for string");
        }
        public override BaseNode AddChild(BaseNode n)
        {
            throw new Exception("Action not valid for string");
        }

        public override BaseNode AddString(string s)
        {
            throw new Exception("Action not valid for string");
        }

        public override void AddAttr(string k, string v)
        {
            throw new Exception("Action not valid for string");
        }

        public override string ToString()
        {
            return Name;
        }

        public override string ToXml(int indent = 0)
        {
            return new string(' ', indent) + Name;
        }

        public override BaseNode getChild(int i)
        {
            throw new Exception("Action not valid for string");
        }

        public override int getChildCount()
        {
            throw new Exception("Action not valid for string");
        }

        public override List<BaseNode> GetCssLike(string xpath)
        {
            throw new Exception("Action not valid for string");
        }
    }
}
