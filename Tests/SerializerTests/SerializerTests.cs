using Binary_Tree.Student;
using Serializer.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Serializer
{
    public partial class SerializerTests
    {
        [Theory]
        [MemberData(nameof(Serializers))]
        public void SerializerTest(BaseSerializer<Student> serializer, string path)
        {
            Assert.Equal(path, serializer.Path);
        }

        [Theory]
        [MemberData(nameof(Serializers))]
        public void SerializationObjectTest(BaseSerializer<Student> serializer, string _)
        {
            var student = new Student("Тончар", "Оливер", "Петрович", new Test("test", DateTime.Now, 8));
            serializer.Serialize(student);
            serializer.Deserialize(out Student deserialized);
            Assert.True(student.Equals(deserialized));
        }
        [Theory]
        [MemberData(nameof(SerializersForCollections))]
        public void SerializationCollectionTest(BaseSerializer<Student> serializer)
        {
            serializer.Serialize(Students);
            serializer.Deserialize(out ICollection<Student> students);
            Assert.True(Enumerable.SequenceEqual(students, Students));
        }
    }
}
