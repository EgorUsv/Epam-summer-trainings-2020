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
        List<T> Collection { get; set; }
        DataTable DataTable { get; set; }

        public DbCollection(ICollection<T> collection, DataTable dataTable)
        {
            DataTable = dataTable;
            Collection = (List<T>)collection;
        }

        public T Read(long id)
        {
            return Collection.FirstOrDefault(x => x.Id == id);
        }
        public void Create(T item)
        {
            DataTable.Rows.Add(item.Deconstruct());
            Collection.Add(item);
        }

        public void Update(T item)
        {
            var obj = DataTable.Rows.Find(item.Id);
            if (obj != null)
            {
                obj.ItemArray = item.Deconstruct();
                var index = Collection.FindIndex(x => x.Id == item.Id);
                Collection.RemoveAt(index);
                Collection.Insert(index, item);
            }
            else 
                throw new ConstraintException();
        }

        public void Delete(long id)
        {
            var obj = DataTable.Rows.Find(id);
            if (obj != null)
            {
                bool relations = false;
                foreach(DataRelation r in DataTable.ChildRelations)
                {
                    if (DataTable.Rows.Find(id).GetChildRows(r).Count() != 0)
                        relations = true;
                }
                if (!relations)
                {
                    DataTable.Rows[DataTable.Rows.IndexOf(obj)].Delete();
                }
                else
                    throw new ConstraintException("ChildRelations is not null");
                Collection.RemoveAll(x => x.Id == id);
            }
        }
        public List<T> GetCollection()
        {
            return new List<T>(Collection);
        }
    }
}
