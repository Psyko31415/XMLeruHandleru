using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node("root", null);
            root.AddString("ost");
            root.AddNode("item");
            root.AddNode("item");
            root.AddNode("item");
            BaseNode node = root.AddNode("item");
            BaseNode str = node.AddString("ostmacka");
            str.AddString("detta kommer bli min syster");
            Console.WriteLine(root);
        }
    }
}
