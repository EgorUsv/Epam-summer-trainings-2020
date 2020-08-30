using SessionDatabase.AbstractClasses;
using SessionDatabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SessionDatabase.Model.Context
{
    public class DbCollection<T> : IDbCollection<T> where T : BaseEntity
    {
        public List<T> Collection { get; private set; }
        DataSet DataSet { get; set; }

        public DbCollection(ICollection<T> collection, DataSet dataSet)
        {
            DataSet = dataSet;
            Collection = (List<T>)collection;
        }

        public T Read(int id)
        {
            return Collection.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T item)
        {
            DataSet.Tables[typeof(T).Name + 's'].Rows.Add(item.Deconstruct());
            Collection.Add(item);
        }

        public void Update(T item)
        {
            var obj = DataSet.Tables[typeof(T).Name + 's'].Rows.Find(item.Id);
            if (obj != null)
            {
                obj.ItemArray = item.Deconstruct();
                var index = Collection.FindIndex(x => x.Id == item.Id);
                Collection.RemoveAt(index);
                Collection.Insert(index, item);
            }
        }

        public void Delete(int id)
        {
            var obj = DataSet.Tables[typeof(T).Name + 's'].Rows.Find(id);
            if (obj != null)
            {
                DataSet.Tables[typeof(T).Name + 's'].Rows.Remove(obj);
                Collection.RemoveAll(x => x.Id == id);
            }
        }
    }
}
