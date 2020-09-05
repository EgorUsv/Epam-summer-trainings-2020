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
            yield return new object[] {new SessionResults(), @"..\..\..\..\ReportsWorker\Reports\sessionResults.xlsx" };
            yield return new object[] {new SessionStatistic() , @"..\..\..\..\ReportsWorker\Reports\sessionStatistic.xlsx" };
            yield return new object[] {new SessionElimination() , @"..\..\..\..\ReportsWorker\Reports\sessionElimination.xlsx" };
        }
    }
}
