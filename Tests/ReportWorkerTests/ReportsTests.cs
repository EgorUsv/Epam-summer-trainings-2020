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

namespace Tests.ReportWorkerTests
{
    public partial class ReportsTests : BaseTest
    {
        [Xunit.Theory]
        [MemberData(nameof(GetData))]
        public void ReportsTest(IReport report,string filePath)
        {
            report.SaveReport(Context, filePath);
        }
    }
}
