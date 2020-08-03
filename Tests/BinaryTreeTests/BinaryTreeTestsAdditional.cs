
using Binary_Tree.Student;
using Binary_Tree.TreeClasses;
using System;
using System.Collections.Generic;

namespace Tests.BinaryTreeTest
{
    public partial class BinaryTreeTests
    {
        static BinaryTree<Student> ReadOnlyTree = InitializeTree();
        static BinaryTree<Student> ChangeableTree = InitializeTree();
        static BinaryTree<Student> InitializeTree()
        {
            var binaryTree = new BinaryTree<Student>();
            binaryTree.AddValue(new Student("Тончар", "Оливер", "Петрович", new Test("test", DateTime.Now, 8)));
            binaryTree.AddValue(new Student("Наумов", "Устин", "Григорьевич", new Test("test", DateTime.Now, 6)));
            binaryTree.AddValue(new Student("Дементьев", "Иосиф", "Вадимович", new Test("test", DateTime.Now, 3)));
            binaryTree.AddValue(new Student("Доронин", "Никита", "Данилович", new Test("test", DateTime.Now, 5)));
            binaryTree.AddValue(new Student("Пахомов", "Емельян", "Богданович", new Test("test", DateTime.Now, 7)));
            binaryTree.AddValue(new Student("Яковлев", "Артемий", "Викторович", new Test("test", DateTime.Now, 6)));
            binaryTree.AddValue(new Student("Шевченко", "Лукьян", "Максимович", new Test("test", DateTime.Now, 5)));
            binaryTree.AddValue(new Student("Таранец", "Шарль", "Данилович", new Test("test", DateTime.Now, 5)));
            return binaryTree;
        }
        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { new Student("Тончар", "Оливер", "Петрович", new Test("test", DateTime.Now, 8)) };
            yield return new object[] { new Student("Наумов", "Устин", "Григорьевич", new Test("test", DateTime.Now, 6)) };
            yield return new object[] { new Student("Дементьев", "Иосиф", "Вадимович", new Test("test", DateTime.Now, 3)) };
            yield return new object[] { new Student("Доронин", "Никита", "Данилович", new Test("test", DateTime.Now, 5)) };
            yield return new object[] { new Student("Пахомов", "Емельян", "Богданович", new Test("test", DateTime.Now, 7)) };
            yield return new object[] { new Student("Яковлев", "Артемий", "Викторович", new Test("test", DateTime.Now, 6)) };
            yield return new object[] { new Student("Шевченко", "Лукьян", "Максимович", new Test("test", DateTime.Now, 5)) };
            yield return new object[] { new Student("Таранец", "Шарль", "Данилович", new Test("test", DateTime.Now, 5)) };
        }
    }
}
