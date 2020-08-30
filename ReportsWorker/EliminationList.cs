using ExcelWorker;
using SessionDatabase.Model.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ReportsWorker
{
    public static class EliminationList
    {
        public static void StudentsForExpulsionSave(DbContext context, string filePath)
        {
            var tables = new List<DataTable>();
            foreach (string groupName in context.Groups.Collection.Select(x => x.GroupName))
            {
                var exam = SessionResults.GetExamResultsForGroup(context, groupName);
                var test = SessionResults.GetTestResultsForGroup(context, groupName);
                var list = GetExpulsionList(exam.Item2).Union(GetExpulsionList(test.Item2)).ToList();
                var result = GetTable(list, groupName);
                if (result != null)
                    tables.Add(result);
            }
            ExcelWriter.SaveTables(tables.ToArray(), filePath);
        }
        static DataTable GetTable(List<string> students, string groupName)
        {
            if (students.Count != 0)
            {
                DataTable dataTable = new DataTable(groupName + "_elimination");
                dataTable.Columns.Add(new DataColumn("Full Name"));
                foreach (var obj in students)
                    dataTable.Rows.Add(obj);
                return dataTable;
            }
            else
                return null;
        }
        static List<string> GetExpulsionList(List<List<object>> table)
        {
            List<string> students = new List<string>();
            foreach (var st in table.Select(x => x[0]).Distinct().ToList())
            {
                var stInfo = table.Where(x => (string)x[0] == (string)st).Select(x => x[2]).Min();
                if (stInfo.GetType() == typeof(bool) && !(bool)stInfo)
                    students.Add((string)st);
                if (stInfo.GetType() == typeof(int) && (int)stInfo < 4)
                    students.Add((string)st);
            }
            return students;
        }
    }
}
