using ExcelWorker;
using ReportsWorker.Interfaces;
using ReportsWorker.Workers;
using SessionDatabase.Model.Context;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportsWorker
{
    /// <summary>
    /// Responsible for creating reports on deductions.
    /// </summary>
    public class SessionElimination : IReport
    {
        /// <summary>
        /// Generates a report on expelled students.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="filePath"></param>
        /// <param name="sort"></param>
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
            SortTables.SortDataTables(tables, sort);
            ExcelWriter.SaveTables(tables.ToArray(), filePath);
        }
        /// <summary>
        /// Сreates a table from the list of expelled students.
        /// </summary>
        /// <param name="students"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Returns a list of those who failed any exam.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        static List<string> GetExamExpulsionList(List<List<object>> table)
        {
            List<string> students = new List<string>();
            foreach (var st in table)
                if (((IEnumerable<int>)st[3]).Any(x => x < 4) || ((IEnumerable<int>)st[4]).Any(x => x < 4))
                    students.Add((string)st[0]);
            return students;
        }
        /// <summary>
        /// Returns a list of those who have not passed any credit.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
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
