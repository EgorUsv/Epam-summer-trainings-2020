using NUnit.Framework;
using ReportsWorker;
using ReportsWorker.Interfaces;
using SessionDatabase.Model.Context;
using SessionDatabase.Model.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tests.SessionDatabaseTests;
using Xunit;
using Assert = Xunit.Assert;

namespace Tests.ReportWorkerTests
{
    public partial class ReportsTests : BaseContext
    {
        [Xunit.Theory]
        [MemberData(nameof(GetData))]
        public void ReportsTest(IReport report,string filePath)
        {
            try
            {
                report.SaveReport(Context, filePath);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
