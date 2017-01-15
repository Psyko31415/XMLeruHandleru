using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLeruHandleru
{
    /**
     * @brief A few "test" used during development to run new features  
     */ 
    class Program
    {
        /**
         * @brief the main function of the program
         * @param args System argumets
         */
        static void Main(string[] args)
        {
            // TestManualCreateAndPrint();
            // TestLoadAndPrintXML();
            // TestLoadAndSaveToFile();
            // TestLoadAndCssSelect();
        }
        /**
         * @brief Test loading of file and selecting with the css like method
         */
        public static void TestLoadAndCssSelect()
        {
            BaseNode root = XMLFileManager.LoadFile("C:\\Users\\Anton\\Desktop\\c#\\XMLeruHandleru\\XMLeruHandleru\\test.xml");
            List<BaseNode> matches = root.GetCssLike("pommes item");
            foreach (BaseNode match in matches)
            {
                Console.WriteLine(match);
                Console.WriteLine("---------------");
            }
        }
        /**
         * @brief Test generating a xml structure and converting it to string
         */
        public static void TestManualCreateAndPrint()
        {
            Node root = new Node("item", null);
            root.AddString("ost");
            root.AddNode("item");
            root.AddNode("item");
            root.AddNode("item");
            BaseNode node = root.AddNode("item");
            BaseNode str = node.AddString("ostmacka");
            Console.WriteLine(root);
        }
        /**
         * @brief Test loading of file and printing 
         */
        public static void TestLoadAndPrintXML()
        {
            BaseNode root = XMLFileManager.LoadFile("C:\\Users\\Anton\\Desktop\\c#\\XMLeruHandleru\\XMLeruHandleru\\test.xml");
            Console.WriteLine(root);
        }
        /**
         * @brief Test loading of file and saving to file
         */
        public static void TestLoadAndSaveToFile()
        {
            BaseNode root = XMLFileManager.LoadFile("C:\\Users\\Anton\\Desktop\\c#\\XMLeruHandleru\\XMLeruHandleru\\test.xml");
            XMLFileManager.SaveToFile("ost.xml", root);
            Console.WriteLine(root);
        }
    }
}
