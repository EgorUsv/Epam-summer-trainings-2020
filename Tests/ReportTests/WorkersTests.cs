using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportsWorker;
using SessionDatabase.Model;
using System;
using System.Collections;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;

namespace Tests
{
    [TestClass]
    public partial class WorkersTests
    {
        string ConnString { get; set; }
        string rPath = "..\\..\\ReportTests\\Reports\\";
        public WorkersTests()
        {
            var path = Path.GetFullPath($@"{Environment.CurrentDirectory}..\..\..\..\SessionDatabase\DataBase");
            ConnString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database.mdf;Integrated Security=True";
            var scriptPath = @"..\..\ReportTests\Reports\script.sql";
            new BaseContext(scriptPath, ConnString);
        }
        [TestMethod]
        public void StatisticsForOneSemester()
        {
            SessionResults results = new SessionResults(ConnString);
            results.SaveReportByTerm(rPath + "statsForSingle.xlsx", 2,2019);
            var tables = ExcelReader.ReadTables(rPath + "statsForSingle.xlsx");
            for(int i = 0; i < tables[0].Rows.Count; i++)
            {
                var arr = GetTestDisciplinesStats().Rows[i].ItemArray;
                CollectionAssert.AreEquivalent(tables[0].Rows[i].ItemArray, new object[] { arr[0], arr[1] });
            }
            for (int i = 0; i < tables[1].Rows.Count; i++)
            {
                var arr = GetTestProfessorStats().Rows[i].ItemArray;
                CollectionAssert.AreEquivalent(tables[1].Rows[i].ItemArray, new object[] { arr[0], arr[1] });
            }
        }
        [TestMethod]
        public void StatisticsForAllSemesters()
        {
            SessionResults results = new SessionResults(ConnString);
            results.SaveReportStatisctic(rPath + "stats.xlsx");
            var tables = ExcelReader.ReadTables(rPath + "stats.xlsx");
            for (int i = 0; i < tables[0].Rows.Count; i++)
                CollectionAssert.AreEquivalent(tables[0].Rows[i].ItemArray, GetTestDisciplinesStats().Rows[i].ItemArray);
            for (int i = 0; i < tables[1].Rows.Count; i++)
                CollectionAssert.AreEquivalent(tables[1].Rows[i].ItemArray, GetTestProfessorStats().Rows[i].ItemArray);
        }
        public DataTable GetTestDisciplinesStats()
        {
            var dataTable = new DataTable("Discipline_statistic");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn(" "),
                new DataColumn("2,2019"),
                new DataColumn("1,2019"),
            });
            dataTable.Rows.Add(new object[] { "Fizika", 6, 5 });
            dataTable.Rows.Add(new object[] { "Fizkyltyra", 8, 5 });
            dataTable.Rows.Add(new object[] { "TViMS", 7, 4 });
            dataTable.Rows.Add(new object[] { "YAPVY", 6, 7 });
            dataTable.Rows.Add(new object[] { "AVS", 6, 6 });
            dataTable.Rows.Add(new object[] { "MCHA", 3, 5 });
            dataTable.Rows.Add(new object[] { "MMA", 5, 8 });
            dataTable.Rows.Add(new object[] { "TivPO", 6, 7 });
            dataTable.Rows.Add(new object[] { "PGZ", 7, 5 });
            return dataTable;
        }
        public DataTable GetTestProfessorStats()
        {
            var dataTable = new DataTable("Discipline_statistic");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn(" "),
                new DataColumn("2,2019"),
                new DataColumn("1,2019"),
            });
            dataTable.Rows.Add(new object[] { "Elena Abramenko Gennadevna", 7, 5 });
            dataTable.Rows.Add(new object[] { " Aleksandr Atvinovskij  Alekseevich", 7, 5 });
            dataTable.Rows.Add(new object[] { "Svetlana Bojkova Nikolaevna", 3, 7 });
            dataTable.Rows.Add(new object[] { "Nadezhda  Bryanceva Vladimirovna", 6, 4 });
            dataTable.Rows.Add(new object[] { "Sergej Ermakov Fedorovich", 6, 6 });
            dataTable.Rows.Add(new object[] { "Anna Kazushchik Aleksandrovna", 6, 6 });
            dataTable.Rows.Add(new object[] { "Valerij Lemeshev Petrovich", 5, 5 });
            dataTable.Rows.Add(new object[] { "Valerij  Selickij Stepanovich", 8, 7 });
            return dataTable;
        }
    }
}
