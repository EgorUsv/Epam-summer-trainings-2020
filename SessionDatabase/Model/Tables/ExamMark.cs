using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Model.Tables
{
    public class ExamMark : BaseEntity
    {
        public long StudentId { get; set; }
        public long ExamId { get; set; }
        public int Mark { get; set; }
        public ExamMark(params object[] values)
        {
            Id = (long)values[0];
            StudentId = (long)values[1];
            ExamId = (long)values[2];
            Mark = (int)values[3];
        }
        public override object[] Deconstruct()
        {
            return new object[] { Id, StudentId, ExamId, Mark };
        }
    }
}
