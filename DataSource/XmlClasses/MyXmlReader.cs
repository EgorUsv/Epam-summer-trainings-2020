using System;
using System.Xml;

namespace DataSource.XmlClasses
{
    /// <summary>
    /// The class is used to read data using 
    /// the XmlReader class.
    /// </summary>
    public static class MyXmlReader
    {
        /// <summary>
        /// Reads data from a file.
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
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
