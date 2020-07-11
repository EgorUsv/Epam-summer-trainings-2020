using DataSource1_2;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Task1_2Tests.DataSourceTests
{
    public class DataSourceTest
    {
        [Fact]
        public void DataSourceReaderTest()
        {
            var expected = "sourceFile.txt";
            var actual = new DataSourceReader().Path;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ReadDataTest()
        {
            var path = "..\\..\\..\\DataSourceTests\\sourceFile.txt";
            var expected = "test text";
            new DataSourceReader(path).ReadData(out var actual);
            Assert.Equal(expected, actual);
        }
    }
}
