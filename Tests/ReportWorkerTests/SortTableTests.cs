using ReportsWorker.Workers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests.ReportWorkerTests
{
    public class SortTableTests
    {
        [Fact]
        public void SortTableTest()
        {
            DataTable sortedDt = GetSortedTable();
            DataTable sortDt = SortTables.SortDataTable(GetTable(), "Surname ASC");
            for(int i = 0; i < sortDt.Rows.Count; i++)
            {
                if (!Enumerable.SequenceEqual(sortedDt.Rows[i].ItemArray, sortDt.Rows[i].ItemArray))
                    Assert.True(false);
            }
        }
        [Fact]
        public void SortTablesTest()
        {
            List<DataTable> sortedDt = GenerateList(10, GetSortedTable());
            List<DataTable> sortDt = GenerateList(10, GetTable());
            sortDt = SortTables.SortDataTables(sortDt, "Surname ASC");
            for(int i = 0; i < sortDt.Count; i++)
            {
                for(int j = 0; j < sortDt[i].Rows.Count;j++)
                {
                    if (!Enumerable.SequenceEqual(sortedDt[i].Rows[j].ItemArray, sortDt[i].Rows[j].ItemArray))
                        Assert.True(false);
                }
            }
        }
        public static DataTable GetTable()
        {
            DataTable dt = new DataTable("testTable");
            dt.Columns.AddRange(new DataColumn[]
            {
                    new DataColumn("Surname"),
                    new DataColumn("Name"),
                    new DataColumn("Patronymic")
            });
            dt.Rows.Add(new object[] { "Kotov", "Ruslan", "Eduardovich" });
            dt.Rows.Add(new object[] { "Orekhov", "Erik", "Sergeevich" });
            dt.Rows.Add(new object[] { "Zvarych", "Nazar", "Bronislavovich" });
            dt.Rows.Add(new object[] { "Sorokin", "Nikita", "Alekseevich" });
            dt.Rows.Add(new object[] { "Ustinov", "Ustin", "Viktorovich" });
            dt.Rows.Add(new object[] { "Lapin", "Ostin", "Fyodorovich" });
            return dt;
        }
        public static DataTable GetSortedTable()
        {
            DataTable dt = new DataTable("testTable");
            dt.Columns.AddRange(new DataColumn[]
            {
                    new DataColumn("Surname"),
                    new DataColumn("Name"),
                    new DataColumn("Patronymic")
            });
            dt.Rows.Add(new object[] { "Kotov", "Ruslan", "Eduardovich" });
            dt.Rows.Add(new object[] { "Lapin", "Ostin", "Fyodorovich" });
            dt.Rows.Add(new object[] { "Orekhov", "Erik", "Sergeevich" });
            dt.Rows.Add(new object[] { "Sorokin", "Nikita", "Alekseevich" });
            dt.Rows.Add(new object[] { "Ustinov", "Ustin", "Viktorovich" });
            dt.Rows.Add(new object[] { "Zvarych", "Nazar", "Bronislavovich" });
            return dt;
        }
        public static List<DataTable> GenerateList(int count,DataTable dt)
        {
            List<DataTable> list = new List<DataTable>();
            for (int i = 0; i < count; i++)
                list.Add(dt);
            return list;
        }
    }
}
