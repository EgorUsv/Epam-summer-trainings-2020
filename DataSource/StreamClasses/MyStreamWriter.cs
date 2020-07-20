using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSource.StreamClasses
{
    public static class MyStreamWriter
    {
        public static void SaveData(string data, string Path)
        {
            using StreamWriter streamWriter = new StreamWriter(Path);
            streamWriter.Write(data);
            streamWriter.Close();
        }
    }
}
