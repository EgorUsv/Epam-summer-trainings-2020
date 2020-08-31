using ReportsWorker;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.ReportWorkerTests
{
    public partial class ReportsTests
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] {new SessionResults(), @"..\sessionResults.xlsx" };
            yield return new object[] {new SessionStatistic() , @"..\sessionStatistic.xlsx" };
            yield return new object[] {new SessionElimination() , @"..\sessionElimination.xlsx" };
        }
    }
}
