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
    public class CrudTest : BaseTest
    {
        [Fact,Order(1)]
        public void CreateTest1()
        {
            Group group = new Group(7L, "testGroup");
            Context.Groups.Create(group);
        }
        [Fact, Order(2)]
        public void CreateTest2()
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
        [Fact, Order(3)]
        public void ReadTest1()
        {
            var result = Context.Groups.Read(2);
            Assert.True(result.GroupName == "IP21");
        }
        [Fact, Order(4)]
        public void ReadTest2()
        {
            var result = Context.Groups.Read(4);
            Assert.True(result == null);
        }
        [Fact, Order(5)]
        public void UpdateTest1()
        {
            Context.Groups.Update(new Group(2L, "IS12"));
            var result = Context.Groups.Read(2L);
            Assert.True(result.GroupName == "IS12");
        }
        [Fact, Order(6)]
        public void UpdateTest2()
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
        [Fact, Order(7)]
        public void DeleteTest1()
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
        [Fact, Order(8)]
        public void DeleteTest2()
        {
            var before = Context.Groups.GetCollection().Count;
            Context.Groups.Create(new Group(100L, "GrName"));
            Context.Groups.Delete(100L);
            var after = Context.Groups.GetCollection().Count;
            Assert.True(before == after);
        }
    }
}
