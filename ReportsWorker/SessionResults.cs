
using ReportsWorker.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;

namespace ReportsWorker
{
    public class SessionResults : BaseReporter
    {
        public void SaveReportStatisctic(string path,string sort = null)
        {
            var tableDis = SaveReportByDisciplines(path, sort);
            var tablePr = SaveReportByProfessors(path, sort);
            ExcelWriter.SaveTables(new DataTable[] { tableDis,tablePr }, path);
        }
        public void SaveReportByTerm(string path, int termNumber, int termYear, string sort = null)
        {
            var dictDis = new Dictionary<string, Dictionary<string, double>>();
            var dictProf = new Dictionary<string, Dictionary<string, double>>();
            var sem = Context.SessionsInfo.FirstOrDefault(x => x.TermNumber == termNumber && x.TermYear == termYear);
            if (sem == default)
                throw new ArgumentException("Incorrect termInfo");
            dictDis.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByDisciplines(sem.TermYear, sem.TermNumber));
            dictProf.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByProfessors(sem.TermYear, sem.TermNumber));
            ExcelWriter.SaveTables(new DataTable[] { CreateTableDis(dictDis,$"{termNumber},{termYear}"), 
                CreateTableProf(dictProf, $"{termNumber},{termYear}") },path);
        }
        DataTable SaveReportByDisciplines(string path, string sort = null)
        {
            var dictByDisciplines = new Dictionary<string, Dictionary<string, double>>();
            foreach (var sem in Context.SessionsInfo)
                dictByDisciplines.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByDisciplines(sem.TermYear, sem.TermNumber));
            return CreateTableDis(dictByDisciplines,"Discipline_statistic");
        }
        DataTable SaveReportByProfessors(string path, string sort = null)
        {
            var dictByProfessors = new Dictionary<string, Dictionary<string, double>>();
            foreach (var sem in Context.SessionsInfo)
                dictByProfessors.Add($"{sem.TermNumber},{sem.TermYear}", AverageScoreByProfessors(sem.TermYear, sem.TermNumber));
            return CreateTableProf(dictByProfessors,"Professors_statistic");
        }
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
