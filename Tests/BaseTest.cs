using SessionDatabase.Model.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class BaseTest
    {
        protected DbContext Context { get; } = DbContext.GetContext();
        public BaseTest()
        {
            var dataAccess = new DataAccess(@"..\..\..\..\SessionDatabase\Database\script.sql");
            Context.LoadContext(dataAccess);
        }
    }
}
