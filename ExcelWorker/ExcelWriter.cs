using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsWorker
{
    public static class ExcelWriter
    {
        public static void SaveTables(DataTable[] dataTables, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            {
                foreach (DataTable table in dataTables)
                {
                    var sheet = package.Workbook.Worksheets.Add(table.TableName);
                    sheet.Cells[1, 1, 1, table.Columns.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        sheet.Cells[1, i + 1].Value = table.Columns[i].ColumnName;
                        sheet.Cells[1, i + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                    for (int i = 2; i < table.Rows.Count + 2; i++)
                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            sheet.Cells[i, j + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            sheet.Cells[i, j + 1].Value = table.Rows[i - 2][j];
                        }
                    sheet.Cells.AutoFitColumns();
                    sheet.Tables.Add(new ExcelAddressBase(1, 1, table.Rows.Count + 1, table.Columns.Count), table.TableName);
                }
                package.SaveAs(new FileInfo(filePath));
            }
        }

    }
}
