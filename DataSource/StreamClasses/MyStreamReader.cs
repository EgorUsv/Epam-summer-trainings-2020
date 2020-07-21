using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSource.StreamClasses
{
    /// <summary>
    /// The class is used to read data using 
    /// the StreamReader class.
    /// </summary>
    public static class MyStreamReader
    {
        /// <summary>
        /// Reads data from a file.
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
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
