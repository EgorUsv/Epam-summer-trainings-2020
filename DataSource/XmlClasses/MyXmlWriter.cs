using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataSource.XmlClasses
{
    /// <summary>
    /// This class is used to write data to a file using 
    /// the XmlWriter class.
    /// </summary>
    public static class MyXmlWriter
    {
        /// <summary>
        /// Writes data to a file.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Path"></param>
        public static void SaveData(string data, string Path)
        {
            XmlWriterSettings x = new XmlWriterSettings();
            x.ConformanceLevel = ConformanceLevel.Auto;
            XmlWriter xmlWriter = XmlWriter.Create(Path, x);
            xmlWriter.WriteString(data);
            xmlWriter.Dispose();
        }
    }
}
