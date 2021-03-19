using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox.Pattern.Repository.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        public string TableName { get; }
        public string IdName { get; }

        public TableAttribute(string tableName, string idName = "Id")
        {
            this.TableName = tableName;
            this.IdName = idName;
        }
    }

    
}
