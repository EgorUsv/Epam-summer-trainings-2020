using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataSource.StreamClasses
{
    /// <summary>
    /// This class is used to write data to a file using 
    /// the StreamWriter class.
    /// </summary>
    public static class MyStreamWriter
    {
        /// <summary>
        /// Writes data to a file.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Path"></param>
        public static void SaveData(string data, string Path)
        {
            using StreamWriter streamWriter = new StreamWriter(Path);
            streamWriter.Write(data);
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }
}
