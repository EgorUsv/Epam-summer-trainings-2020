using SessionDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsWorker.BaseClasses
{
    public class BaseReporter
    {
        protected ModelDataContext Context { get; set; }
        public BaseReporter()
        {
            Context = new ModelDataContext(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                @"C:\Users\Egor\Desktop\Task7\SessionDatabase_FR4.8\Database\Database.mdf;Integrated Security=True");
        }
    }
}