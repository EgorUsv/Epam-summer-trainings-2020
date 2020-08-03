using Binary_Tree.Deserializer;
using Binary_Tree.Student;
using Binary_Tree.TreeClasses;
using Serializer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.BinaryTreeTest
{
    public partial class BinaryTreeTests
    {
        [Fact]
        public void AddValueTest()
        {
            var tree = new BinaryTree<Student>();
            Student student1 = new Student("Тончар", "Оливер", "Петрович", new Test("test", DateTime.Now, 8));
            Student student2 = new Student("Наумов", "Устин", "Григорьевич", new Test("test", DateTime.Now, 6));
            Student student3 = new Student("Дементьев", "Иосиф", "Вадимович", new Test("test", DateTime.Now, 3));
            tree.AddValue(student1);
            tree.AddValue(student2);
            tree.AddValue(student3);
            List<Student> list = tree.GetTreeInList();
            Assert.True(Enumerable.SequenceEqual(list, new List<Student>() { student1, student3, student2 }));
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void SearchValueTest(Student student)
        {
            Student findedStudent = ReadOnlyTree.SearchValue(student);
            Assert.True(findedStudent.CompareTo(student) == 0);
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void DeleteValueTest(Student student)
        {
            ChangeableTree.DeleteValue(student);
            var result = ChangeableTree.SearchValue(student);
            Assert.True(result == null);
        }
        [Fact]
        public void SerializeTest()
        {
            List<Student> studentsList = ReadOnlyTree.GetTreeInList();
            new MyXmlSerializer<Student>("testFile.xml").Serialize(studentsList);
            new MyXmlSerializer<Student>("testFile.xml").Deserialize(out ICollection<Student> deserializedTree);
            BinaryTree<Student> tree = TreeRecreator<Student>.Deserializer(deserializedTree);
            Assert.True(Enumerable.SequenceEqual(studentsList, tree.GetTreeInList()));
        }
    }
}
