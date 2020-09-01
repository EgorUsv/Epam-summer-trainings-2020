using SessionDatabase.Interfaces;
using System;
using System.Collections.Generic;
using SessionDatabase.Model.Context;
using System.Text;
using Xunit;
using System.Linq;
using NUnit.Framework;
using Assert = Xunit.Assert;

namespace Tests.SessionDatabaseTests
{
    public class ContextTest : BaseTest
    {
        [Fact,Order(1)]
        public void SaveTest()
        {
            var createdGroup = new SessionDatabase.Model.Tables.Group(10L, "testGroup");
            Context.Groups.Create(createdGroup);
            var dbAccess = new DbAccess();
            Context.Save(dbAccess);
            Context.LoadContext(new DbAccess());
            var readGroup = Context.Groups.GetCollection().Last();
            Assert.Equal(createdGroup.GroupName, readGroup.GroupName);
            Context.Groups.Delete(readGroup.Id);
            Context.Save(dbAccess);
        }
    }
}
