using DataSource.StreamClasses;
using DataSource.XmlClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.DataSourceTests
{
    public class DataSourceTests
    {
        [Fact]
        public void XmlTest()
        {
            var expected = "Hello world\nHello world";
            MyXmlWriter.SaveData(expected, "testfile.xml");
            string actual = MyXmlReader.ReadData("testfile.xml");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void StreamTest()
        {
            var expected = "Hello world\nHello world";
            MyStreamWriter.SaveData(expected, "testfile.xml");
            string actual = MyStreamReader.ReadData("testfile.xml");
            Assert.Equal(expected, actual);
        }
    }
}
