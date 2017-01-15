using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    /**
     * @brief A class with functions to interact with the file system. 
     * Exampel usage: 
     * \include XMLFileManagerExample.cs
     */
    class XMLFileManager
    {
        /** 
         * @brief Saves the xml structure to a file
         * @param path The path to where the xml should be saved
         * @param node The node to save from
         * @return void
         * 
         */
        public static void SaveToFile(string path, BaseNode node)
        {
            File.WriteAllText(path, node.ToString());
        }
        /**
         * @brief Loads a xml file
         * @param path The filepath to the file relative to cwd or absolute
         * @return The xml structure
         * 
         */
        public static BaseNode LoadFile(string path)
        {
            return LoadString(File.ReadAllText(path));
        }
        /**
         * @brief Loads an xml string
         * @param xml The string to be loaded
         * @return The xml structure
         * 
         */
        public static BaseNode LoadString(string xml)
        {
            return RecLoadXml(xml, null);
        }
        /**
         * @brief The recursive function that converts a xml string to the internal datastructure
         * @param xml The string to be converted
         * @param parent The parent node of the xml string, or null if current xml is root
         * @return The loaded node
         */
        private static BaseNode RecLoadXml(string xml, BaseNode parent)
        {
            int depth = 0, startIndex = 0, stopIndex = 0, lastTagStart = 0, headStart = 0, headStop = 0;
            int stringStart = 0, stringStop = 0;
            bool inString = false, isStartNode = false, somethingAdded = false;
            BaseNode node = null;

            for (int i = 0; i < xml.Length; i++)
            {
                char c = xml[i];

                if (c == '"')
                {
                    inString = !inString;
                }

                if (c == '<' && !inString)
                {
                    isStartNode = i + 1 < xml.Length && xml[i + 1] != '/';
                    lastTagStart = i;

                    if (depth == 0)
                    {
                        headStart = i + 1;
                        stringStop = i;
                        AddStringToTree(xml, stringStart, stringStop, parent);
                        somethingAdded = true;
                    }
                }

                if (c == '>' && !inString)
                {
                    if (isStartNode)
                    {
                        if (depth == 0)
                        {
                            startIndex = i + 1;
                            headStop = i;
                        }
                        depth++;
                    }
                    else
                    {
                        depth--;
                        if (depth == 0)
                        {
                            stringStart = i + 1;
                            stopIndex = lastTagStart;
                            somethingAdded = true;
                            string name;
                            Dictionary<string, string> attrs;
                            LoadHead(xml.Substring(headStart, headStop - headStart), out name, out attrs);
                            node = new Node(name, parent, attrs);
                            RecLoadXml(xml.Substring(startIndex, stopIndex - startIndex), node);

                            if (parent != null)
                            {
                                parent.AddChild(node);
                            }
                        }
                    }
                }
            }
            if (!somethingAdded)
            {
                AddStringToTree(xml, 0, xml.Length, parent);
            }
            return node;   
        }
        /**
         * @brief Adds a string node to the internal tree. Used by RecLoadXml()
         * @param xml The xml string to gather a data string from 
         * @param stringStart The start index for the datastring
         * @param stringStop The stop index for the datastring
         * @param parent The parent node, to which the newly created StringNode is appenden
         * @return void
         */
        private static void AddStringToTree(string xml, int stringStart, int stringStop, BaseNode parent)
        {
            string content = xml.Substring(stringStart, stringStop - stringStart).Trim();
            if (content.Length != 0)
            {
                BaseNode node = new StringNode(content, parent);
                if (parent != null)
                {
                    parent.AddChild(node);
                }
            }
        }
        /**
         * @brief Parses and loads the xml head for a node
         * @param data The head itself
         * @param name The computed name of the node
         * @param attrs The computed attributes of the node
         * @return void
         */
        private static void LoadHead(string data, out string name, out Dictionary<string, string> attrs)
        {
            string[] split = data.Split(' ');
            name = split[0];
            attrs = new Dictionary<string, string>();
            for (int i = 1; i < split.Length; i++)
            {
                string[] kvp = split[i].Split('=');
                attrs[kvp[0]] = kvp[1].Trim(new char[] { '"' });
            }
        }
    }
}
