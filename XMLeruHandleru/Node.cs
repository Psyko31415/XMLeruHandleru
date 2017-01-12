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

        public override string ToString()
        {
            string res = "<" + Name + AttributesToString() + ">";
            foreach (BaseNode n in children)
            {
                res += n.ToString();
            }

            res += "</" + Name + ">";
            return res;
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