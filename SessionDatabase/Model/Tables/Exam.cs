using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Model.Tables
{
    public class Exam : BaseEntity
    {
        public long GroupId { get; set; }
        public long DisciplineId { get; set; }
        public int Term { get; set; }
        public DateTime ExamDate { get; set; }
        public Exam(params object[] values)
        {
            Id = (long)values[0];
            GroupId = (long)values[1];
            DisciplineId = (long)values[2];
            Term = (int)values[3];
            ExamDate = (DateTime)values[4];
        }
        public override object[] Deconstruct()
        {
            return new object[] { Id, GroupId, DisciplineId, Term, ExamDate };
        }
    }
}
