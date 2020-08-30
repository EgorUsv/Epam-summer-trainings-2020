using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ExcelWorker
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
                        var rowIndex = 0;
                        while (rowIndex < sheet.Dimension.Rows)
                            table.Rows.Add(sheet.Cells[rowIndex, rowIndex, rowIndex, sheet.Dimension.Columns].ToArray());
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
