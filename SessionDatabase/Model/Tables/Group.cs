using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Model.Tables
{
    public class Group : BaseEntity
    {
        public string GroupName { get; set; }
        public Group(params object[] values)
        {
            Id = (long)values[0];
            GroupName = (string)values[1];
        }
        public override object[] Deconstruct()
        {
            return new object[] { Id, GroupName };
        }
    }
}
