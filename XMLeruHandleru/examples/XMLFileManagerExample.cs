namespace XMLeruHandleru.examples
{
    class XMLFileManagerExample
    {
        static void Main(string[] args)
        {
            // path to your xml file
            string pathToXmlFile = "text.xml";

            // Load xml from your file into a root node
            BaseNode rootNodeFromFile = XMLFileManager.LoadFile(pathToXmlFile);

            // A xml string contaning the xml to be loaded
            string xml = "<parent name=\"1\"><child></child></parent>";

            // Load the content of the string into another root node
            BaseNode rootNodeFromString = XMLFileManager.LoadString(xml);

            // do some actions with rootNodeFromFile and rootNodeFromString
            // ...
            // ...

            // The file you wish to save to
            string pathToSaveTo = "save.xml";

            // Saves the xml
            XMLFileManager.SaveToFile(pathToSaveTo, rootNodeFromFile);
        }
    }
}
