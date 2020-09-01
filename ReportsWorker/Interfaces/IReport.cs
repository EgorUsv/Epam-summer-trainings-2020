using SessionDatabase.Model.Context;

namespace ReportsWorker.Interfaces
{
    public interface IReport
    {
        void SaveReport(DbContext context, string filePath, string sort = null);
    }
}
