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
            //TestManualCreateAndPrint();
            //TestLoadAndPrintXML();
            TestLoadAndSaveToFile();
        }

        public static void TestManualCreateAndPrint()
        {
            Node root = new Node("root", null);
            root.AddString("ost");
            root.AddNode("item");
            root.AddNode("item");
            root.AddNode("item");
            BaseNode node = root.AddNode("item");
            BaseNode str = node.AddString("ostmacka");
            Console.WriteLine(root);
        }

        public static void TestLoadAndPrintXML()
        {
            BaseNode root = XMLFileManager.LoadFile("C:\\Users\\Anton\\Desktop\\c#\\XMLeruHandleru\\XMLeruHandleru\\test.xml");
            Console.WriteLine(root);
        }

        public static void TestLoadAndSaveToFile()
        {
            BaseNode root = XMLFileManager.LoadFile("C:\\Users\\Anton\\Desktop\\c#\\XMLeruHandleru\\XMLeruHandleru\\test.xml");
            XMLFileManager.SaveToFile("ost.xml", root);
            Console.WriteLine(root);
        }
    }
}
