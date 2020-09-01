using SessionDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SessionDatabase.Model.Context
{
    public class DbAccess : IDbAccess
    {
        internal string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Egor\source\repos\Egor_Usachev_Task6\SessionDatabase\Database\Database.mdf;Integrated Security=True";
        private readonly SqlConnection connection;
        public DbAccess(string scriptPath)
        {
            connection = new SqlConnection(connectionString);
            FillDataBaseIfEmpty(scriptPath);
        }
        public DbAccess()
        {
            connection = new SqlConnection(connectionString);
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
                table.PrimaryKey = new DataColumn[] { table.Columns[0] };
                dataSet.Tables.Add(table);
            }
            connection.Close();
            InitializeDataRelations(dataSet);
            return dataSet;
        }
        private void InitializeDataRelations(DataSet dataSet)
        {
            foreach(DataTable table in dataSet.Tables)
            {
                for(int i = 1; i < table.Columns.Count; i++)
                {
                    if (Regex.IsMatch(table.Columns[i].ColumnName, @"\w*Id$"))
                    {
                        string tableName = table.Columns[i].ColumnName.Substring(0, table.Columns[i].ColumnName.Length - 2);
                        var relation = new DataRelation(table.TableName + "_FK_" + table.Columns[i].ColumnName,
                            dataSet.Tables[tableName + "s"].Columns[0], table.Columns[i]);
                        foreach (DataRow row in table.Rows)
                        {
                            if(dataSet.Tables[tableName + "s"].Rows.Find(row[0]) != null)
                                row.SetParentRow(dataSet.Tables[tableName + "s"].Rows.Find(row[i]), relation);
                        }
                        dataSet.Relations.Add(relation);
                    } 
                }
            }
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
            foreach(DataTable table in dataSet.Tables)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [{table.TableName}];", connection);
                new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dataSet,table.TableName);
            }
            connection.Close();
        }
    }
}
