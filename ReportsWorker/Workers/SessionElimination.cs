using ExcelWorker;
using ReportsWorker.Interfaces;
using SessionDatabase.Model.Context;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportsWorker
{
    public class SessionElimination : IReport
    {
        public void SaveReport(DbContext context, string filePath, string sort = null)
        {
            var tables = new List<DataTable>();
            foreach (string groupName in context.Groups.GetCollection().Select(x => x.GroupName))
            {
                var exam = SessionResults.GetExamResultsForGroup(context, groupName);
                var cred = SessionResults.GetTestResultsForGroup(context, groupName);
                var list = GetCreditExpulsionList(cred.Item2).Union(GetExamExpulsionList(exam.Item2)).ToList();
                var result = GetTable(list, groupName);
                if (result != null)
                    tables.Add(result);
            }
            if (sort != null)
                foreach (var table in tables)
                    table.DefaultView.Sort = sort;
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
        static List<string> GetExamExpulsionList(List<List<object>> table)
        {
            List<string> students = new List<string>();
            foreach (var st in table)
                if (((IEnumerable<int>)st[3]).Any(x => x < 4) || ((IEnumerable<int>)st[4]).Any(x => x < 4))
                    students.Add((string)st[0]);
            return students;
        }
        static List<string> GetCreditExpulsionList(List<List<object>> table)
        {
            List<string> students = new List<string>();
            foreach (var st in table)
                if (((IEnumerable<bool>)st[3]).Any(x => !x) || ((IEnumerable<bool>)st[4]).Any(x => !x))
                    students.Add((string)st[0]);
            return students;
        }
    }
}
