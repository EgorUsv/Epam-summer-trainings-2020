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
    /// <summary>
    /// Responsible for connecting and working with the database.
    /// </summary>
    public class DbAccess : IDbAccess
    {
        /// <summary>
        /// Сontains the connection string
        /// </summary>
        private string ConnectionString { get; set; }
        /// <summary>
        /// Сontains a connection to the database.
        /// </summary>
        private readonly SqlConnection connection;
        /// <summary>
        /// Initializes DbAccess with a script to fill the database with 
        /// data and a connection string.
        /// </summary>
        /// <param name="scriptPath"></param>
        /// <param name="connectionString"></param>
        public DbAccess(string scriptPath,string connectionString)
        {
            ConnectionString = connectionString;
            connection = new SqlConnection(ConnectionString);
            FillDataBaseIfEmpty(scriptPath);
        }
        /// <summary>
        /// Connects to the database if the connection is not open yet.
        /// </summary>
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
        /// <summary>
        /// Fill the database with data if it is empty.
        /// </summary>
        /// <param name="scriptPath"></param>
        private void FillDataBaseIfEmpty(string scriptPath)
        {
            CreateConnection();
            if (GetTableNames().Count == 0)
                new SqlCommand(File.ReadAllText(@scriptPath), connection).ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Loads the database into Dataset.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Loads relationships between tables.
        /// </summary>
        /// <param name="dataSet"></param>
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
        /// <summary>
        /// Returns a list of table names.
        /// </summary>
        /// <returns></returns>
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
