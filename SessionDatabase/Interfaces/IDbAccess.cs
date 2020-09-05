using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SessionDatabase.Interfaces
{
    /// <summary>
    /// Reflects the interface to connect to a data source.
    /// </summary>
    public interface IDbAccess
    {
        /// <summary>
        /// Saves dataSet to data source
        /// </summary>
        /// <param name="dataSet"></param>
        void Save(DataSet dataSet);
        /// <summary>
        /// Loads a dataSet from a data source.
        /// </summary>
        /// <returns></returns>
        DataSet LoadDataSet();
    }
}
