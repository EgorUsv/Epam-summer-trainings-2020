using NUnit.Framework;
using SessionDatabase.Model.Context;
using SessionDatabase.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xunit;
using Assert = Xunit.Assert;

namespace Tests.SessionDatabaseTests
{
    public class CrudTest : BaseContext
    {
        [Fact]
        public void CreateNewRowTest()
        {
            Group group = new Group(7L, "testGroup");
            Context.Groups.Create(group);
        }
        [Fact]
        public void CreateExistingRowTest()
        {
            try
            {
                Group group = new Group(2L, "testGroup");
                Context.Groups.Create(group);
                Assert.True(false);
            }
            catch(ConstraintException)
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void ReadExistingRowTest()
        {
            var result = Context.Groups.Read(2);
            Assert.True(result.GroupName == "IP21");
        }
        [Fact]
        public void ReadNonExistingEntryTest()
        {
            var result = Context.Groups.Read(4);
            Assert.True(result == null);
        }
        [Fact]
        public void UpdateExistingRowTest()
        {
            Context.Groups.Update(new Group(2L, "IS12"));
            var result = Context.Groups.Read(2L);
            Assert.True(result.GroupName == "IS12");
        }
        [Fact]
        public void UpdateNonExistingTest()
        {
            try
            {
                Context.Groups.Update(new Group(5L, "IS12"));
                var result = Context.Groups.Read(2L);
            }
            catch(ConstraintException)
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void DeleteExsistingRowTest()
        {
            try
            {
                Context.Groups.Delete(1L);
                Assert.True(false);
            }
            catch(ConstraintException)
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void DeleteUnrelatedRowTest()
        {
            var before = Context.Groups.GetCollection().Count;
            Context.Groups.Create(new Group(100L, "GrName"));
            Context.Groups.Delete(100L);
            var after = Context.Groups.GetCollection().Count;
            Assert.True(before == after);
        }
    }
}
