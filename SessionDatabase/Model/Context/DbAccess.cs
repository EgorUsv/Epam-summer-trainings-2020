using SessionDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace SessionDatabase.Model.Context
{
    public class DataAccess : IDbAccess
    {
        internal string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='|DataDirectory|\SessionDatabase\Database\Database.mdf';Integrated Security=True";
        private readonly SqlConnection connection;
        public DataAccess(string scriptPath)
        {
            connection = new SqlConnection(connectionString);
            FillDataBaseIfEmpty(scriptPath);
        }
        private void CreateConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
            catch
            {
                connection.Close();
                throw new Exception("Can't connect to database.");
            }
        }
        private void FillDataBaseIfEmpty(string scriptPath)
        {
            CreateConnection();
            if (GetTableNames().Count == 0)
                new SqlCommand(File.ReadAllText(@scriptPath), connection).ExecuteNonQuery();
            connection.Close();
        }
        public DataSet LoadDataSet()
        {
            CreateConnection();
            var dataSet = new DataSet();
            foreach (string tableName in GetTableNames())
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM [{tableName}];", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = tableName;
                dataSet.Tables.Add(table);
            }
            connection.Close();
            return dataSet;
        }
        private List<string> GetTableNames()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", connection);
            using SqlDataReader reader = command.ExecuteReader();
            List<string> list = new List<string>();
            while (reader.Read())
                list.Add((string)reader["TABLE_NAME"]);
            return list;
        }
        public void Save(DataSet dataSet)
        {
            CreateConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("", connection);
            adapter.Update(dataSet);
            connection.Close();
        }
    }
}
