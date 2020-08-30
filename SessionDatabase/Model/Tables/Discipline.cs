using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Model.Tables
{
    public class Discipline : BaseEntity
    {
        public string DisciplineName { get; set; }
        public Discipline(params object[] values)
        {
            Id = (long)values[0];
            DisciplineName = (string)values[1];
        }

        public override object[] Deconstruct()
        {
            return new object[] { Id, DisciplineName };
        }
    }
}
