using System;
using System.IO;

namespace DataSource1_2
{
    public class DataSourceReader
    {
        public string Path { get; }
        public DataSourceReader(string path = "sourceFile.txt")
        {
            Path = path;
        }
        public bool ReadData(out string result)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                    result = sr.ReadToEnd();
                return true;
            }
            catch (Exception e)
            {
                result = e.Message;
                return false;
            }
        }
    }
}
