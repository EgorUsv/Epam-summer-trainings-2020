using SessionDatabase.AbstractClasses;
using SessionDatabase.Interfaces;
using SessionDatabase.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SessionDatabase.Model.Context
{
    public class DbContext
    {
        static DbContext Context { get; set; }
        DataSet DataSet { get; set; }
        private DbContext()
        { }
        public static DbContext GetContext()
        {
            if (Context == null)
                Context = new DbContext();
            return Context;
        }
        public void LoadContext(IDbAccess dataAccess)
        {
            if (dataAccess == null)
                throw new ArgumentNullException("dataAccess");
            DataSet = dataAccess.LoadDataSet();
            Disciplines = new DbCollection<Discipline>(GetCollection<Discipline>(DataSet.Tables[typeof(Discipline).Name + 's']), DataSet);
            Exams = new DbCollection<Exam>(GetCollection<Exam>(DataSet.Tables[typeof(Exam).Name + 's']), DataSet);
            ExamMarks = new DbCollection<ExamMark>(GetCollection<ExamMark>(DataSet.Tables[typeof(ExamMark).Name + 's']), DataSet);
            Groups = new DbCollection<Group>(GetCollection<Group>(DataSet.Tables[typeof(Group).Name + 's']), DataSet);
            Students = new DbCollection<Student>(GetCollection<Student>(DataSet.Tables[typeof(Student).Name + 's']), DataSet);
            Tests = new DbCollection<Credit>(GetCollection<Credit>(DataSet.Tables[typeof(Credit).Name + 's']), DataSet);
            TestResults = new DbCollection<CreditResult>(GetCollection<CreditResult>(DataSet.Tables[typeof(CreditResult).Name + 's']), DataSet);
        }
        private ICollection<T> GetCollection<T>(DataTable dataTable) where T : BaseEntity
        {
            if (dataTable != null)
            {
                ICollection<T> collection = new List<T>();
                foreach (DataRow row in dataTable.Rows)
                {
                    T obj = (T)Activator.CreateInstance(typeof(T), row.ItemArray);
                    collection.Add(obj);
                }
                return collection;
            }
            return null;
        }
        public void Save(IDbAccess dataAccess)
        {
            dataAccess.Save(DataSet);
        }
        public DbCollection<Discipline> Disciplines { get; set; }
        public DbCollection<Exam> Exams { get; set; }
        public DbCollection<ExamMark> ExamMarks { get; set; }
        public DbCollection<Group> Groups { get; set; }
        public DbCollection<Student> Students { get; set; }
        public DbCollection<Credit> Tests { get; set; }
        public DbCollection<CreditResult> TestResults { get; set; }
    }
}
