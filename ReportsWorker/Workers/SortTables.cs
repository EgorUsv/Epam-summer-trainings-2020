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
        public static void SortDataTables(ICollection<DataTable> tables,string sort)
        {
            if(sort != null)
            for (int i = 0; i < tables.Count(); i++)
                SortDataTable(tables.ElementAt(i), sort);
        }
    }
}
