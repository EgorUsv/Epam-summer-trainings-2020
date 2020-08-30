using System;
using System.Collections.Generic;
using System.Text;

namespace SessionDatabase.AbstractClasses
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public abstract object[] Deconstruct();
    }
}
