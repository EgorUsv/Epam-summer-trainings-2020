
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class BaseContext
    {
        SqlConnection Connection { get; set; }
        public BaseContext(string @scriptPath,string @conString)
        {
            Connection = new SqlConnection(conString);
            Connection.Open();
            if (IsEmpty())
            {
                string command = File.ReadAllText(scriptPath);
                new SqlCommand(command, Connection).ExecuteNonQuery();
            }
            Connection.Close();
        }
        private bool IsEmpty()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", Connection);
            using SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            if (reader.Read())
                return false;
            return true;
        }
    }
}
