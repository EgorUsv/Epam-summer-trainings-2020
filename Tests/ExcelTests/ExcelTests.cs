
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportsWorker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Tests.ExcelWorkerTests
{
    [TestClass]
    public class ExcelTests
    {
        DataTable DataTable { get; set; }
        public ExcelTests()
        {
            DataTable = new DataTable("testTable");
            DataTable.Columns.AddRange(new DataColumn[]
            {
                    new DataColumn("Name"),
                    new DataColumn("Status"),
                    new DataColumn("Number")
            });
            DataTable.Rows.Add(new object[] { "Alex", "Ok",1 });
            DataTable.Rows.Add(new object[] { "Mason", "Ok",2 });
            DataTable.Rows.Add(new object[] { "Mason", "Not good",3 });
        }
        [TestMethod]
        public void ExcelTest()
        {
            ExcelWriter.SaveTables(new DataTable[] { DataTable }, "testExcel.xlsx");
            var table = ExcelReader.ReadTables("testExcel.xlsx")[0];
            for(int iRow = 0; iRow < DataTable.Rows.Count; iRow++)
            {
                CollectionAssert.AreEqual(table.Rows[iRow].ItemArray, DataTable.Rows[iRow].ItemArray);
            }
        }
    }
}
