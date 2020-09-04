using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportsWorker;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class WorkersTests
    {
        [TestMethod]
        public void Test1()
        {
            var path = Path.GetFullPath($@"{Environment.CurrentDirectory}..\..\..\..\SessionDatabase\DataBase");
            var connString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database.mdf;Integrated Security=True";
            var scriptPath = @"..\..\ReportTests\Reports\script.sql";
            new BaseContext(scriptPath, connString);
            SessionResults results = new SessionResults();
            results.SaveReportStatisctic("stats.xlsx");
        }
    }
}
