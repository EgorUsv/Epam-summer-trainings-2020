using ExcelWorker;
using SessionDatabase.Model.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ReportsWorker
{
    public static class SessionResults
    {
        public static void SaveSessionResults(DbContext context,string filePath, string sort = null)
        {
            var tables = new List<DataTable>();
            foreach (string groupName in context.Groups.Collection.Select(x => x.GroupName))
            {
                var exam = GetExamResultsForGroup(context, groupName);
                var test = GetTestResultsForGroup(context, groupName);
                var examTable = PrepareForSentSessionResult(exam.Item2, exam.Item1, groupName);
                var testTable = PrepareForSentSessionResult(test.Item2, test.Item1, groupName);
                if (examTable != null)
                    tables.Add(examTable);
                if (testTable != null)
                    tables.Add(testTable);
            }
            if (sort != null)
                foreach (var table in tables)
                    table.DefaultView.Sort = sort;
            ExcelWriter.SaveTables(tables.ToArray(), filePath);
        }
        static DataTable PrepareForSentSessionResult(List<List<object>> col, string kName, string groupName)
        {
            if (col != null && col.Count > 0)
            {
                DataTable dataTable = new DataTable(groupName + '_' + kName);
                dataTable.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("Full name"),
                    new DataColumn("Discipline name"),
                    kName == "Exams" ? new DataColumn("Mark") : new DataColumn("Credit"),
                    new DataColumn("Semester number"),
                    new DataColumn("Completion date"),
                });
                if (kName == "Exams")
                    dataTable.Columns[2].DataType = typeof(int);
                else
                    dataTable.Columns[2].DataType = typeof(bool);
                dataTable.Columns[3].DataType = typeof(int);
                foreach (var student in col)
                    dataTable.Rows.Add(student.ToArray());
                return dataTable;
            }
            return null;
        }
        internal static (string, List<List<object>>) GetExamResultsForGroup(DbContext context, string groupName)
        {
            long groupId = context.Groups.Collection.First(z => z.GroupName == groupName).Id;
            var groupExam = context.Exams.Collection.Join(context.Groups.Collection, a => a.GroupId, b => b.Id,
                (a, b) => new
                {
                    ExamId = a.Id,
                    a.DisciplineId,
                    a.Term,
                    a.ExamDate,
                    b.GroupName
                }).Where(x => x.GroupName == groupName);
            var groupExamDisc = groupExam.Join(context.Disciplines.Collection, a => a.DisciplineId, b => b.Id,
                (a, b) => new
                {
                    a.ExamId,
                    a.Term,
                    a.ExamDate,
                    b.DisciplineName
                });
            var groupExamDiscMark = context.ExamMarks.Collection.Join(groupExamDisc, a => a.ExamId, b => b.ExamId,
                (a, b) => new
                {
                    a.StudentId,
                    a.Mark,
                    b.ExamDate,
                    b.DisciplineName,
                    b.Term
                });
            var result = groupExamDiscMark.Join(context.Students.Collection.Where(x => x.GroupId == groupId),
                a => a.StudentId,
                b => b.Id,
                (a, b) => new
                {
                    b.LastName,
                    b.FirstName,
                    b.Patronymic,
                    a.ExamDate,
                    a.DisciplineName,
                    a.Mark,
                    a.Term
                });
            var table = new List<List<object>>();
            foreach (var st in result)
            {
                List<object> list = new List<object>();
                list.AddRange(new object[] { st.LastName + ' ' + st.FirstName + ' ' +
                    st.Patronymic, st.DisciplineName,st.Mark,st.Term,st.ExamDate });
                table.Add(list);
            }
            return ("Exams", table);
        }
        internal static (string, List<List<object>>) GetTestResultsForGroup(DbContext context, string groupName)
        {
            var groupTest = context.Tests.Collection.Join(context.Groups.Collection, a => a.GroupId, b => b.Id,
                (a, b) => new
                {
                    TestId = a.Id,
                    a.DisciplineId,
                    a.Term,
                    a.CreditDate,
                    b.GroupName
                }).Where(x => x.GroupName == groupName);
            var groupTestDisc = groupTest.Join(context.Disciplines.Collection, a => a.DisciplineId, b => b.Id,
                (a, b) => new
                {
                    a.TestId,
                    a.Term,
                    a.CreditDate,
                    b.DisciplineName
                });
            var groupTestDiscMark = context.TestResults.Collection.Join(groupTestDisc, a => a.CreditId, b => b.TestId,
                (a, b) => new
                {
                    a.StudentId,
                    a.Result,
                    b.CreditDate,
                    b.DisciplineName,
                    b.Term,
                });
            var result = context.Students.Collection.Join(groupTestDiscMark, a => a.Id, b => b.StudentId,
                (a, b) => new
                {
                    a.LastName,
                    a.FirstName,
                    a.Patronymic,
                    b.CreditDate,
                    b.DisciplineName,
                    b.Result,
                    b.Term
                });
            var table = new List<List<object>>();
            foreach (var st in result)
            {
                List<object> list = new List<object>();
                list.AddRange(new object[] { st.LastName + ' ' + st.FirstName + ' ' +
                    st.Patronymic, st.DisciplineName,st.Result,st.Term,st.CreditDate });
                table.Add(list);
            }
            return ("Credits", table);
        }
    }
}
