using SessionDatabase.Model.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests
{
    public class BaseContext
    {
        protected DbContext Context { get; } = DbContext.GetContext();
        protected DbAccess DbAccess { get; set; }
        public BaseContext()
        {
            var path = Path.GetFullPath($@"{Environment.CurrentDirectory}..\..\..\..\..\SessionDatabase\DataBase");
            string scriptPath = @"..\..\..\..\SessionDatabase\Database\script.sql";
            DbAccess = new DbAccess(scriptPath,@$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database.mdf;Integrated Security=True");
            Context.LoadContext(DbAccess);
        }
    }
}
