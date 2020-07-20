using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DataSource.XmlClasses
{
    public static class MyXmlWriter
    {
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
