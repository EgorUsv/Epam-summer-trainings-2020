using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSource.StreamClasses
{
    public static class MyStreamReader
    {
        public static string ReadData(string Path)
        {
            using StreamReader streamReader = new StreamReader(Path);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }
    }
}
