using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    class XMLFileManager
    {
        public static void SaveToFile(string path, BaseNode node)
        {
            File.WriteAllText(path, node.ToString());
        }

        public static BaseNode LoadFile(string path)
        {
            return LoadString(File.ReadAllText(path));
        }

        public static BaseNode LoadString(string xml)
        {
            return RecLoadXml(xml, null);
        }
        
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
