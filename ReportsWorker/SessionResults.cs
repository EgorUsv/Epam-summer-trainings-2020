
using SessionDatabase.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.IO;
using System.Linq;

namespace ReportsWorker
{
    /// <summary>
    /// Responsible for issuing session results
    /// </summary>
    public class SessionResults
    {
        /// <summary>
        /// Contains database context.
        /// </summary>
        ModelDataContext Context { get; set; }
        /// <summary>
        /// Initializes the object with a database connection string.
        /// </summary>
        /// <param name="connString"></param>
        public SessionResults(string @connString)
        {
            Context = new ModelDataContext(connString);
        }
        /// <summary>
        /// Saves a report for all semesters.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sort"></param>
        public void SaveReportStatisctic(string path,string sort = null)
        {
            var tableDis = GetReportByDisciplines();
            var tablePr = GetReportByProfessors();
            tableDis = SortTables.SortDataTable(tableDis, sort);
            tablePr = SortTables.SortDataTable(tablePr, sort);
            ExcelWriter.SaveTables(new DataTable[] { tableDis,tablePr }, path);
        }
        /// <summary>
        /// Saves a report for a specific semester.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="termNumber"></param>
        /// <param name="termYear"></param>
        public void SaveReportByTerm(string path, int termNumber, int termYear)
        {
            var dictDis = new Dictionary<string, Dictionary<string, double>>();
            var dictProf = new Dictionary<string, Dictionary<string, double>>();
            var sem = Context.SessionsInfo.FirstOrDefault(x => x.TermNumber == termNumber && x.TermYear == termYear);
            if (sem == default)
                throw new ArgumentException("Incorrect termInfo");
            dictDis.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByDisciplines(sem.TermYear, sem.TermNumber));
            dictProf.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByProfessors(sem.TermYear, sem.TermNumber));
            ExcelWriter.SaveTables(new DataTable[] { CreateTableDis(dictDis,"Discipline_statistic"), 
                CreateTableProf(dictProf, "Professors_statistic") },path);
        }
        /// <summary>
        /// Creates a report by discipline
        /// </summary>
        /// <returns></returns>
        DataTable GetReportByDisciplines()
        {
            var dictByDisciplines = new Dictionary<string, Dictionary<string, double>>();
            foreach (var sem in Context.SessionsInfo)
                dictByDisciplines.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByDisciplines(sem.TermYear, sem.TermNumber));
            return CreateTableDis(dictByDisciplines,"Discipline_statistic");
        }
        /// <summary>
        /// Сreates report by professors.
        /// </summary>
        /// <returns></returns>
        DataTable GetReportByProfessors()
        {
            var dictByProfessors = new Dictionary<string, Dictionary<string, double>>();
            foreach (var sem in Context.SessionsInfo)
                dictByProfessors.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByProfessors(sem.TermYear, sem.TermNumber));
            return CreateTableProf(dictByProfessors,"Professors_statistic");
        }
        /// <summary>
        /// Converts the resulting collection to a DataTable.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataTable CreateTableDis(Dictionary<string, Dictionary<string, double>> value,string tableName)
        {
            DataTable table = new DataTable(tableName);
            table.Columns.Add(" ");
            foreach (var colName in value.Keys)
                table.Columns.Add(colName);
            foreach(string name in Context.Disciplines.Select(x=>x.DisciplineName))
            {
                List<object> marks = new List<object>();
                marks.Add(name);
                foreach(var term in value)
                {
                    var mark = term.Value.FirstOrDefault(x => x.Key == name);
                    if (mark.Key != null)
                        marks.Add(mark.Value);
                    else
                        marks.Add("--");
                }
                table.Rows.Add(marks.ToArray());
            }
            return table;
        }
        /// <summary>
        /// Converts the resulting collection to a DataTable
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        DataTable CreateTableProf(Dictionary<string, Dictionary<string, double>> value, string tableName)
        {
            DataTable table = new DataTable(tableName);
            table.Columns.Add(" ");
            foreach (var colName in value.Keys)
                table.Columns.Add(colName);
            foreach (string name in Context.Professors.Select(x=> x.FirstName + " " + x.LastName + " " + x.Patronymic))
            {
                List<object> marks = new List<object>();
                marks.Add(name);
                foreach (var term in value)
                {
                    var mark = term.Value.FirstOrDefault(x => x.Key == name);
                    if (mark.Key != null)
                        marks.Add(mark.Value);
                    else
                        marks.Add("--");
                }
                table.Rows.Add(marks.ToArray());
            }
            return table;
        }
        /// <summary>
        /// Returns a collection containing information about disciplines.
        /// </summary>
        /// <param name="termYear"></param>
        /// <param name="termNumber"></param>
        /// <returns></returns>
        Dictionary<string, double> AverageScoreByDisciplines(long termYear,long termNumber)
        {
            var result =  from ex in Context.Exams
                          join gr in Context.Groups on ex.GroupId equals gr.GroupId
                          join dis in Context.Disciplines on ex.DisciplineId equals dis.DisciplineId
                          join s in Context.SessionsInfo.Where(x => x.TermNumber == termNumber && x.TermYear == termYear)
                             on ex.SessionId equals s.SessionInfoId
                          join res in Context.ExamResults on ex.ExamId equals res.ExamId
                          select new
                          {
                              dis.DisciplineName,
                              res.Mark,
                          };
            var dict = new Dictionary<string, double>();
            foreach (string disName in result.Select(x=>x.DisciplineName).Distinct())
            {
                double av = result.Where(x => x.DisciplineName == disName).Select(x => x.Mark).Average();
                dict.Add(disName, av);
            }
            return dict;
        }
        /// <summary>
        /// Returns a collection containing information about professors.
        /// </summary>
        /// <param name="termYear"></param>
        /// <param name="termNumber"></param>
        /// <returns></returns>
        Dictionary<string, double> AverageScoreByProfessors(long termYear, long termNumber)
        {
            var result =  from ex in Context.Exams
                          join gr in Context.Groups on ex.GroupId equals gr.GroupId
                          join pr in Context.Professors on ex.ProfessorId equals pr.ProfessorId
                          join s in Context.SessionsInfo.Where(x => x.TermNumber == termNumber && x.TermYear == termYear)
                             on ex.SessionId equals s.SessionInfoId
                          join res in Context.ExamResults on ex.ExamId equals res.ExamId
                          select new
                          {
                              FullName = pr.FirstName + " " + pr.LastName + " " + pr.Patronymic,
                              res.Mark,
                          };
            var dict = new Dictionary<string, double>();
            foreach (string disName in result.Select(x => x.FullName).Distinct())
            {
                double av = result.Where(x => x.FullName == disName).Select(x => x.Mark).Average();
                dict.Add(disName, av);
            }
            return dict;
        }
    }
}
