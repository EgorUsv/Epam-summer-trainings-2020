using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Model.Tables
{
    public class Student : BaseEntity
    {
        public long GroupId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(params object[] values)
        {
            Id = (long)values[0];
            GroupId = (long)values[1];
            LastName = (string)values[2];
            FirstName = (string)values[3];
            Patronymic = (string)values[4];
            Gender = (string)values[5];
            DateOfBirth = (DateTime)values[6];
        }
        public override object[] Deconstruct()
        {
            return new object[] { Id, GroupId, LastName, FirstName, 
                Patronymic, Gender, DateOfBirth };
        }
    }
}
