using SessionDatabase.Model.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportsWorker.Interfaces
{
    public interface IReport
    {
        void SaveReport(DbContext context, string filePath,string sort = null);
    }
}
