using System;
using System.Xml;

namespace DataSource.XmlClasses
{
    public static class MyXmlReader
    {
        public static string ReadData(string Path)
        {
            XmlReaderSettings x = new XmlReaderSettings();
            x.ConformanceLevel = ConformanceLevel.Auto;
            XmlReader xmlReader = XmlReader.Create(Path, x);
            xmlReader.MoveToContent();
            string result = xmlReader.ReadContentAsString();
            xmlReader.Close();
            xmlReader.Dispose();
            return result;
        }
    }
}
