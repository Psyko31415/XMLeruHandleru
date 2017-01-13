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
        private List<BaseNode> Children { get; set; }
        private Dictionary<string, string> Attributes { get; set; }

        public Node(string name, BaseNode parent, Dictionary<string, string> attributes)
        {
            Children = new List<BaseNode>();
            Name = name;
            Parent = parent;
            Attributes = attributes;
        }

        public Node(string name, BaseNode parent) : this(name, parent, new Dictionary<string, string>()) { }

        public Node(string name) : this(name, null) { }

        public Node() : this("") { }

        public override BaseNode AddNode(string name)
        {
            Node n = new Node(name, this);
            return AddChild(n);
        }

        public override BaseNode AddChild(BaseNode n)
        {
            Children.Add(n);
            return n;
        }

        public override BaseNode AddString(string s)
        {
            StringNode n = new StringNode(s, this);
            Children.Add(n);
            return n;
        }

        public override void AddAttr(string k, string v)
        {
            Attributes[k] = v;
        }

        private string AttributesToString()
        {
            string res = "";
            foreach(KeyValuePair<string, string> kvp in Attributes)
            {
                res += " " + kvp.Key + "=\"" + kvp.Value + "\""; 
            }
            return res;
        }

        public override string ToXml(int indent = 0)
        {
            string indentString = new string(' ', indent);
            string res = indentString + "<" + Name + AttributesToString() + ">\n";
            foreach (BaseNode n in Children)
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
            return Children[i];
        }

        public override int getChildCount()
        {
            return Children.Count;
        }

        public override List<BaseNode> GetCssLike(string xpath)
        {
            return null;
        }


    }
}