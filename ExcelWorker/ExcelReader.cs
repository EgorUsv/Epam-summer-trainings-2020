using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsWorker
{
    public static class ExcelReader
    {
        static public DataTable[] ReadTables(string filePath = "testFile.xlsx")
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var fileinfo = new FileInfo(filePath);
            if (fileinfo.Exists)
            {
                using var package = new ExcelPackage(fileinfo);
                {
                    List<DataTable> tables = new List<DataTable>();
                    foreach (var sheet in package.Workbook.Worksheets)
                    {
                        var table = new DataTable(sheet.Name);
                        foreach (var col in sheet.Tables[0].Columns)
                            table.Columns.Add(col.Name);
                        for (int i = 2; i < sheet.Dimension.Rows + 1; i++)
                        {
                            List<object> list = new List<object>();
                            for (int j = 1; j < sheet.Dimension.Columns + 1; j++)
                                list.Add(sheet.Cells[i, j].Value);
                            table.Rows.Add(list.ToArray());
                        }
                        tables.Add(table);
                    }
                    return tables.ToArray();
                }
            }
            else
                throw new FileNotFoundException($"Unable to find a {filePath}");
        }
    }
}
