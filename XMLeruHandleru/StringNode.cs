﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{    /**
     * @brief Represents a string value within the document
     */
    class StringNode : BaseNode
    {
        /**
         * @brief Constructs a new StringNode
         * @param name The name and content for the node
         * @param parent Its parent or null if the node is root
         */
        public StringNode(string name, BaseNode parent)
        {
            Name = name;
            Parent = parent;
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override string GetAttr(string k)
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override BaseNode AddNode(string name)
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override BaseNode AddChild(BaseNode n)
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override BaseNode AddString(string s)
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override void AddAttr(string k, string v)
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Returns a string representation of itself
         * @return Its content
         */
        public override string ToString()
        {
            return Name;
        }
        /**
         * @brief Converts itself to xml
         * @param indent The number of spaces to indent
         * @return The formated xml string
         */
        public override string ToXml(int indent = 0)
        {
            return new string(' ', indent) + Name;
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override BaseNode GetChild(int i)
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override int GetChildCount()
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Throws an exception because the action can not be applied to a StringNode
         */
        public override List<BaseNode> GetCssLike(string xpath)
        {
            throw new Exception("Action not valid for string");
        }
        /**
         * @brief Does nothing because StringNodes are not desierable when serching
         */
        internal override void GetCssLikeRec(string[] rules, ref List<BaseNode> res)
        {
            
        }
        /**
         * @brief Since StringNodes are not desierable when serching no rule matches them
         * @return false
         */
        internal override bool RulesMatches(string[] rules, int i)
        {
            return false;
        }
    }
}
