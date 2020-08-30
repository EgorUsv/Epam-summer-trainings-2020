using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Model.Tables
{
    public class CreditResult : BaseEntity
    {
        public long CreditId { get; set; }
        public long StudentId { get; set; }
        public bool Result { get; set; }
        public CreditResult(params object[] values)
        {
            Id = (long)values[0];
            StudentId = (long)values[1];
            CreditId = (long)values[2];
            Result = (bool)values[3];
        }
        public override object[] Deconstruct()
        {
            return new object[] { Id, StudentId, CreditId, Result };
        }
    }
}
