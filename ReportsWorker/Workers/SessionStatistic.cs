using ExcelWorker;
using ReportsWorker.Interfaces;
using SessionDatabase.Model.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ReportsWorker
{
    /// <summary>
    /// Responsible for statistical reports.
    /// </summary>
    public class SessionStatistic : IReport
    {
        /// <summary>
        /// Saves statistical reports.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="filePath"></param>
        /// <param name="sort"></param>
        public void SaveReport(DbContext context, string filePath, string sort = null)
        {
            var tables = new List<List<object>>();
            foreach (string groupName in context.Groups.GetCollection().Select(x => x.GroupName))
            {
                var examForGroup = GetMinAvgMaxResults(context, groupName);
                if (examForGroup.Item1 != null && examForGroup.Item1.Count != 0)
                    tables.Add(examForGroup.Item1);
                if (examForGroup.Item2 != null && examForGroup.Item2?.Count != 0)
                    tables.Add(examForGroup.Item2);
            }
            var table = PrepareForSentSessionResult(tables);
            if (table != null)
            {
                if (sort != null)
                    table.DefaultView.Sort = sort;
                ExcelWriter.SaveTables(new DataTable[] { table }, filePath);
            }
        }
        /// <summary>
        /// Generates a tuple with data about 1 and 2 semester of the given group
        /// </summary>
        /// <param name="context"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        static (List<object>, List<object>) GetMinAvgMaxResults(DbContext context, string groupName)
        {
            var group_exam = context.Exams.GetCollection().Join(context.Groups.GetCollection(),
                a => a.GroupId,
                b => b.Id,
                (a, b) => new
                {
                    ExamId = a.Id,
                    a.Term,
                    a.ExamDate,
                    b.GroupName
                }).Where(x => x.GroupName == groupName);
            var group_exam_mark = context.ExamMarks.GetCollection().Join(group_exam,
               a => a.ExamId,
               b => b.ExamId,
               (a, b) => new
               {
                   a.StudentId,
                   a.Mark,
                   b.ExamDate,
                   b.Term
               });
            var firstSession = group_exam_mark.Where(x => x.Term == 1).Select(x => x.Mark);
            var secondSession = group_exam_mark.Where(x => x.Term == 2).Select(x => x.Mark);
            List<object> firstSessionResult = null, secondSessionResult = null;
            if (firstSession.Count() != 0)
            {
                firstSessionResult = new List<object>
                {
                    groupName,firstSession.Min(),Math.Round(firstSession.Average(),2),firstSession.Max(),1
                };
            }
            if (secondSession.Count() != 0)
            {
                secondSessionResult = new List<object>
                {
                    groupName,secondSession.Min(),Math.Round(secondSession.Average(),2),secondSession.Max(),2
                };
            }
            return (firstSessionResult, secondSessionResult);
        }
        /// <summary>
        /// Сreates DataTable from collection.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        static DataTable PrepareForSentSessionResult(List<List<object>> col)
        {
            if (col != null && col.Count > 0)
            {
                DataTable dataTable = new DataTable("EstimatesStatistic");
                dataTable.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("Group name"),
                    new DataColumn("Minimum grade"),
                    new DataColumn("Average grade"),
                    new DataColumn("Maximum grade"),
                    new DataColumn("Semester number"),
                });
                foreach (var obj in col)
                    dataTable.Rows.Add(obj.ToArray());
                return dataTable;
            }
            else
                return null;
        }
    }
}
