using SessionDatabase.Model.Context;

namespace ReportsWorker.Interfaces
{
    /// <summary>
    /// Contains basic report properties.
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Saves the report to a file.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="filePath"></param>
        /// <param name="sort"></param>
        void SaveReport(DbContext context, string filePath, string sort = null);
    }
}
