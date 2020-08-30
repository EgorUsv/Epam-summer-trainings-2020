using SessionDatabase.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.Interfaces
{
    public interface IDbCollection<T>
    {
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
