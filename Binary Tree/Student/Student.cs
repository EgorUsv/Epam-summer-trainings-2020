
using Serializer.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Binary_Tree.Student
{
    [Serializable]
    public class Student : BaseFunctions, IComparable<Student>, ISerialize
    {
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public Test TestInfo { get; set; }
        public Student(string surname, string name, string patronymic, Test testInfo)
        {
            if (surname != null)
                Surname = surname;
            if (name != null)
                Name = name;
            if (patronymic != null)
                Patronymic = patronymic;
            TestInfo = testInfo;
        }
        public Student()
        { }
        public override bool Equals(object obj)
        {
            if (obj is Student && (obj as Student).Name == Name
                && (obj as Student).Surname == Surname
                && (obj as Student).Patronymic == Patronymic)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return GetStringHashCode(Surname, 4) ^ GetStringHashCode(Name, 3) ^
                GetStringHashCode(Patronymic,2) ^ TestInfo.GetHashCode();
        }
        public int CompareTo([AllowNull] Student other)
        {
            string thisStudent = Name + Surname + Patronymic;
            string otherStudent = other.Name + other.Surname + other.Patronymic;
            return thisStudent.CompareTo(otherStudent);
        }
    }
}
