using ReportsWorker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Tests.ReportWorkerTests
{
    public partial class ReportsTests
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] {new SessionResults(), @"..\..\..\..\ReportsWorker\Reports\sessionResults.xlsx", 
                @"..\..\..\..\ReportsWorker\Reports\MyResults\sessionResults.xlsx" };
            yield return new object[] {new SessionStatistic() , @"..\..\..\..\ReportsWorker\Reports\sessionStatistic.xlsx", 
                @"..\..\..\..\ReportsWorker\Reports\MyResults\sessionStatistic.xlsx" };
            yield return new object[] {new SessionElimination() , @"..\..\..\..\ReportsWorker\Reports\sessionElimination.xlsx", 
                @"..\..\..\..\ReportsWorker\Reports\MyResults\sessionElimination.xlsx" };
        }
    }
}
