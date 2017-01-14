using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    class Node : BaseNode
    {
        private List<BaseNode> Children { get; set; }
        private Dictionary<string, string> Attributes { get; set; }
        /**
         * @brief Creates a new node without children
         * @param name The name of the node
         * @param parent The nodes parent or null if the node is root
         * @param attributes The attributes associated with the node
         */
        public Node(string name, BaseNode parent, Dictionary<string, string> attributes)
        {
            Children = new List<BaseNode>();
            Name = name;
            Parent = parent;
            Attributes = attributes;
        }
        /**
         * @brief Creates a new node without children and attributes
         * @param name The name of the node
         * @param parent The nodes parent or null if the node is root
         */
        public Node(string name, BaseNode parent) : this(name, parent, new Dictionary<string, string>()) { }
        /**
         * @brief Creates a new root node without children, attributes and parent
         * @param name The name of the node
         */
        public Node(string name) : this(name, null) { }

        /**
         * @brief Creates and adds a child Node 
         * @param name The name of the to be node
         * @return The created node
         */
        public override BaseNode AddNode(string name)
        {
            Node n = new Node(name, this);
            return AddChild(n);
        }
        /**
         * @brief Adds a child
         * @param n The child to add
         * @return The added child
         */
        public override BaseNode AddChild(BaseNode n)
        {
            Children.Add(n);
            return n;
        }
        /**
         * @brief Creates and adds a child StringNode 
         * @param s The content of the to be node
         * @return The created node
         */
        public override BaseNode AddString(string s)
        {
            StringNode n = new StringNode(s, this);
            Children.Add(n);
            return n;
        }
        /**
         * @brief Adds an attribute
         * @param k The attribute key
         * @param v The attribute value
         * @return void
         */
        public override void AddAttr(string k, string v)
        {
            Attributes[k] = v;
        }
        /**
         * @brief Converts the dictionary of attributes to a string 
         * @return The string
         */
        private string AttributesToString()
        {
            string res = "";
            foreach(KeyValuePair<string, string> kvp in Attributes)
            {
                res += " " + kvp.Key + "=\"" + kvp.Value + "\""; 
            }
            return res;
        }
        /**
         * @brief Creates an xml string
         * @param indent the number of spaces indentation for current indentation level
         * @return The xml string
         */
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
        /**
         * @brief Creates a string representation of the node
         * @return The corresponding xml string
         */
        public override string ToString()
        {
            return ToXml();
        }
        /**
         * @brief Returns the i:th child
         * @param i The index of child to get from
         * @return The child
         */
        public override BaseNode GetChild(int i)
        {
            return Children[i];
        }
        /**
         * @brief Returns the number of children
         * @return The number of childre
         */
        public override int GetChildCount()
        {
            return Children.Count;
        }
        /**
         * @brief Uses a css like query format to fetch nodes and text see <a href="">here for more info</a>
         * @param query The query <a href="">more info</a>
         * @return A list of the matching nodes
         */
        public override List<BaseNode> GetCssLike(string query)
        {
            List<BaseNode> res = new List<BaseNode>();
            string[] rules = query.Split(' ');
            if (RulesMatches(rules, rules.Length - 1))
            {
                res.Add(this);
            }

            GetCssLikeRec(rules, ref res);
            
            return res;
        }


        public override void GetCssLikeRec(string[] rules, ref List<BaseNode> res)
        {
            foreach (BaseNode child in Children)
            {
                child.GetCssLikeRec(rules, ref res);
                if (child.RulesMatches(rules, rules.Length - 1))
                {
                    res.Add(child);
                }
            }
        }

        public override bool RulesMatches(string[] rules, int i)
        {
            if (i == -1)
            {
                return true;
            }

            MatchCollection tmp = Regex.Matches(rules[i], @"\[([^\[\]]+)\]");
            if (tmp.Count > 0)
            {
                string[] kvp = tmp[0].Groups[1].Value.Split('=');
                
                if (kvp.Length == 2)
                {
                    string value;
                    if (Attributes.TryGetValue(kvp[0], out value))
                    {
                        if (value != kvp[1])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            string name = Regex.Matches(rules[i], @"([^\[\]=:]*)")[0].Groups[0].Value;
            if (name != Name)
            {
                return false;
            }
            
            if (Parent == null)
            {
                return i == 0; // aka return if the entire ruleset was iterated or not
            }

            return Parent.RulesMatches(rules, i - 1);
        }

    }
}