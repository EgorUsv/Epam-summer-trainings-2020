using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Model.Tables
{
    public class Credit : BaseEntity
    {
        public long GroupId { get; set; }
        public long DisciplineId { get; set; }
        public int Term { get; set; }
        public DateTime CreditDate { get; set; }
        public Credit(params object[] values)
        {
            Id = (long)values[0];
            GroupId = (long)values[1];
            DisciplineId = (long)values[2];
            Term = (int)values[3];
            CreditDate = (DateTime)values[4];
        }
        public override object[] Deconstruct()
        {
            return new object[] { Id, GroupId, DisciplineId, Term, CreditDate };
        }
    }
}
