using GroupDocs.Comparison;
using NUnit.Framework;
using ReportsWorker;
using ReportsWorker.Interfaces;
using System;
using Xunit;
using Assert = Xunit.Assert;

namespace Tests.ReportWorkerTests
{
    public partial class ReportsTests : BaseContext
    {
        [Xunit.Theory]
        [MemberData(nameof(GetData))]
        public void ReportsTest(IReport report,string filePath,string testFilePath)
        {
            try
            {
                report.SaveReport(Context, filePath);
                using Comparer comparer = new Comparer(filePath);
                comparer.Add(testFilePath);
                comparer.Compare();
                if (comparer.GetChanges().Length != 0)
                    throw new Exception("Documents are not equal");
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
