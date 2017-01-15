using System;
using System.Collections.Generic;

namespace XMLeruHandleru.examples
{
    class NodeExample
    {
        static void Main(string[] args)
        {
            // create a new node called root
            BaseNode root = new Node("root");

            // add 5 childnodes to root with the name item add an attribute test set to their index mod 2
            for (int i = 0; i < 5; i++)
            {
                BaseNode item = root.AddNode("item");
                item.AddAttr("test", (i % 2).ToString());
            }

            // select every node of type item where the test attribute is equal to 1
            List<BaseNode> items = root.GetCssLike("item[test=1]");

            // Add the string Look some text to the previously selected nodes 
            foreach (BaseNode item in items)
            {
                item.AddString("Look some text");
            }

            // print the content of the root node
            Console.WriteLine(root);
        }
    }
}
