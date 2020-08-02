
using Serializer.Classes;
using System.Collections.Generic;
using Tests.TestObjects;

namespace Tests.Serializer
{
    public partial class SerializerTests
    {
        public static ICollection<Student> Students = InitializeList();
        public static IEnumerable<object[]> Serializers()
        {
            yield return new object[] { new MyXmlSerializer<Student>("testObject.xml"), "testObject.xml" };
            yield return new object[] { new MyJsonSerializer<Student>("testObject.json"), "testObject.json" };
            yield return new object[] { new MyBinarySerializer<Student>("testObject.bin"), "testObject.bin" };
        }
        public static IEnumerable<object[]> SerializersForCollections()
        {
            yield return new object[] { new MyXmlSerializer<Student>("testCollection.xml") };
            yield return new object[] { new MyJsonSerializer<Student>("testCollection.json") };
            yield return new object[] { new MyBinarySerializer<Student>("testCollection.bin") };
        }
        public static List<Student> InitializeList()
        {
            List<Student> students = new List<Student>();
            foreach (var student in BinaryTreeTests.Data())
                students.Add((Student)student[0]);
            return students;
        }
    }
}
