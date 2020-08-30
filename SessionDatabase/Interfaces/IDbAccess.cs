using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SessionDatabase.Interfaces
{
    public interface IDbAccess
    {
        void Save(DataSet dataSet);
        DataSet LoadDataSet();
    }
}
