using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    class Node : BaseNode
    {
        private List<BaseNode> children;
        private Dictionary<string, string> attributes;

        public Node(string name, Node parent)
        {
            Name = name;
            Parent = parent;
            children = new List<BaseNode>();
            attributes = new Dictionary<string, string>();
        }

        public override BaseNode AddNode(string name)
        {
            Node n = new Node(name, this);
            return AddNode(n);
        }

        public override BaseNode AddNode(Node n)
        {
            children.Add(n);
            return n;
        }

        public override BaseNode AddString(string s)
        {
            StringNode n = new StringNode(s, this);
            children.Add(n);
            return n;
        }

        public override void AddAttr(string k, string v)
        {
            attributes[k] = v;
        }

        private string AttributesToString()
        {
            string res = "";
            foreach(KeyValuePair<string, string> kvp in attributes)
            {
                res += " " + kvp.Key + "=\"" + kvp.Value + "\""; 
            }
            return res;
        }

        public override string ToXml(int indent = 0)
        {
            string indentString = new string(' ', indent);
            string res = indentString + "<" + Name + AttributesToString() + ">\n";
            foreach (BaseNode n in children)
            {
                res += n.ToXml(indent + 2) + "\n";
            }

            res += indentString + "</" + Name + ">";
            return res;
        }

        public override string ToString()
        {
            return ToXml();
        }

        public override BaseNode getChild(int i)
        {
            return children[i];
        }

        public override int getChildCount()
        {
            return children.Count;
        }

        public override List<BaseNode> GetCssLike(string xpath)
        {
            return null;
        }
    }
}