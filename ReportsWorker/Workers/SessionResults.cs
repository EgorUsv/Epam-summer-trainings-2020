using ExcelWorker;
using ReportsWorker.Interfaces;
using ReportsWorker.Workers;
using SessionDatabase.Model.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportsWorker
{
    /// <summary>
    /// Responsible for creating reports on session results.
    /// </summary>
    public class SessionResults : IReport
    {
        /// <summary>
        /// Generates a report on the results of all sessions
        /// </summary>
        /// <param name="context"></param>
        /// <param name="filePath"></param>
        /// <param name="sort"></param>
        public void SaveReport(DbContext context, string filePath, string sort = null)
        {
            var tables = new List<DataTable>();
            foreach (string groupName in context.Groups.GetCollection().Select(x => x.GroupName))
            {
                var exam = GetExamResultsForGroup(context, groupName);
                var test = GetTestResultsForGroup(context, groupName);
                var examTable = GetTable(exam.Item2, exam.Item1, groupName);
                var testTable = GetTable(test.Item2, test.Item1, groupName);
                if (examTable != null)
                    tables.Add(examTable);
                if (testTable != null)
                    tables.Add(testTable);
            }
            SortTables.SortDataTables(tables, sort);
            ExcelWriter.SaveTables(tables.ToArray(), filePath);
        }
        /// <summary>
        /// Returns the input collection as a table.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="knowType"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        private static DataTable GetTable(List<List<object>> collection, string knowType, string groupName)
        {
            if (collection != null && collection.Count > 0)
            {
                DataTable dataTable = new DataTable(groupName + '_' + knowType);
                dataTable.Columns.Add(new DataColumn("Full name"));
                foreach (string disNames in (IEnumerable<string>)collection[0][1])
                    dataTable.Columns.Add(disNames + " (I sem)   ");
                dataTable.Columns.Add("    ");
                foreach (string disNames in (IEnumerable<string>)collection[0][2])
                    dataTable.Columns.Add(disNames + " (II sem)  ");
                if (knowType == "Exams")
                    LoadExamsTable(dataTable, collection);
                else
                    LoadCreditTable(dataTable, collection);
                return dataTable;
            }
            return null;
        }
        /// <summary>
        /// Loads exam data from a collection into a DataTable.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="collection"></param>
        private static void LoadExamsTable(DataTable dataTable, List<List<object>> collection)
        {
            foreach (var student in collection)
            {
                List<object> stInfo = new List<object> { student[0] };
                foreach (var disName in (IEnumerable<int>)student[3])
                    stInfo.Add(disName);
                stInfo.Add("");
                foreach (var disName in (IEnumerable<int>)student[4])
                    stInfo.Add(disName);
                dataTable.Rows.Add(stInfo.ToArray());
            }
        }
        /// <summary>
        /// Loads credit data from a collection into a DataTable.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="collection"></param>
        private static void LoadCreditTable(DataTable dataTable, List<List<object>> collection)
        {
            foreach (var student in collection)
            {
                List<object> stInfo = new List<object> { student[0] };
                foreach (var disName in (IEnumerable<bool>)student[3])
                    stInfo.Add(disName);
                stInfo.Add("");
                foreach (var disName in (IEnumerable<bool>)student[4])
                    stInfo.Add(disName);
                dataTable.Rows.Add(stInfo.ToArray());
            }
        }
        /// <summary>
        /// Returns a tuple with information about the knowledge test type fro group and a data collection.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        internal static (string, List<List<object>>) GetExamResultsForGroup(DbContext context, string groupName)
        {
            var groupExam = context.Exams.GetCollection().Join(context.Groups.GetCollection(), a => a.GroupId, b => b.Id,
                (a, b) => new
                {
                    ExamId = a.Id,
                    a.DisciplineId,
                    a.Term,
                    a.ExamDate,
                    b.GroupName,
                }).Where(x => x.GroupName == groupName);
            var groupExamDisc = groupExam.Join(context.Disciplines.GetCollection(), a => a.DisciplineId, b => b.Id,
                (a, b) => new
                {
                    a.ExamId,
                    a.Term,
                    a.ExamDate,
                    b.DisciplineName
                });
            var groupExamDiscMark = context.ExamMarks.GetCollection().Join(groupExamDisc, a => a.ExamId, b => b.ExamId,
                (a, b) => new
                {
                    a.StudentId,
                    a.Mark,
                    b.ExamDate,
                    b.DisciplineName,
                    b.Term
                });
            var students = context.Students.GetCollection().Where(x => groupExamDiscMark.Select(z => z.StudentId).Contains(x.Id));
            var result = students.GroupJoin(groupExamDiscMark,
                a => a.Id,
                b => b.StudentId,
                (a, b) => new
                {
                    a.LastName,
                    a.FirstName,
                    a.Patronymic,
                    DisciplineNames1 = b.Where(x => x.Term == 1).Select(x => x.DisciplineName),
                    Marks1 = b.Where(x => x.Term == 1).Select(x => x.Mark),
                    DisciplineNames2 = b.Where(x => x.Term == 2).Select(x => x.DisciplineName),
                    Marks2 = b.Where(x => x.Term == 2).Select(x => x.Mark),
                });
            var table = new List<List<object>>();
            foreach (var st in result)
            {
                List<object> list = new List<object>();
                list.AddRange(new object[] { st.LastName + ' ' + st.FirstName + ' ' +
                    st.Patronymic, st.DisciplineNames1,st.DisciplineNames2,st.Marks1,st.Marks2 });
                table.Add(list);
            }
            return ("Exams", table);
        }
        /// <summary>
        /// Returns a tuple with information about the knowledge test type for group and a data collection.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="groupName"></param>
        internal static (string, List<List<object>>) GetTestResultsForGroup(DbContext context, string groupName)
        {
            var groupCredit = context.Credits.GetCollection().Join(context.Groups.GetCollection(), a => a.GroupId, b => b.Id,
                (a, b) => new
                {
                    TestId = a.Id,
                    a.DisciplineId,
                    a.Term,
                    a.CreditDate,
                    b.GroupName
                }).Where(x => x.GroupName == groupName);
            var groupCreditDisc = groupCredit.Join(context.Disciplines.GetCollection(), a => a.DisciplineId, b => b.Id,
                (a, b) => new
                {
                    a.TestId,
                    a.Term,
                    a.CreditDate,
                    b.DisciplineName
                });
            var groupCreditDiscMark = context.CreditResults.GetCollection().Join(groupCreditDisc, a => a.CreditId, b => b.TestId,
                (a, b) => new
                {
                    a.StudentId,
                    a.Result,
                    b.CreditDate,
                    b.DisciplineName,
                    b.Term,
                });
            var students = context.Students.GetCollection().Where(x => groupCreditDiscMark.Select(z => z.StudentId).Contains(x.Id));
            var result = students.GroupJoin(groupCreditDiscMark, a => a.Id, b => b.StudentId,
                (a, b) => new
                {
                    a.LastName,
                    a.FirstName,
                    a.Patronymic,
                    DisciplineNames1 = b.Where(x => x.Term == 1).Select(x => x.DisciplineName),
                    Results1 = b.Where(x => x.Term == 1).Select(x => x.Result),
                    DisciplineNames2 = b.Where(x => x.Term == 2).Select(x => x.DisciplineName),
                    Results2 = b.Where(x => x.Term == 2).Select(x => x.Result),
                });
            var table = new List<List<object>>();
            foreach (var st in result)
            {
                List<object> list = new List<object>();
                list.AddRange(new object[] { st.LastName + ' ' + st.FirstName + ' ' +
                    st.Patronymic, st.DisciplineNames1,st.DisciplineNames2,st.Results1,st.Results2 });
                table.Add(list);
            }
            return ("Credits", table);
        }
    }
}
