using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ReportsWorker.Workers
{
    public class SortTables
    {
        public static DataTable SortDataTable(DataTable table,string sort)
        {
            if (sort != null)
                table.DefaultView.Sort = sort;
            return table.DefaultView.ToTable();
        }
        public static List<DataTable> SortDataTables(ICollection<DataTable> tables,string sort)
        {
            if (sort != null)
            {
                DataTable[] sortedArr = tables.ToArray();
                for (int i = 0; i < sortedArr.Length; i++)
                {
                    sortedArr[i].DefaultView.Sort = sort;
                    sortedArr[i] = sortedArr[i].DefaultView.ToTable();
                }
                return new List<DataTable>(sortedArr);
            }
            return tables.ToList();
        }
    }
}
