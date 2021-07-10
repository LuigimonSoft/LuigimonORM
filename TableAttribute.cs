using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using Dapper;
using Microsoft.CSharp.RuntimeBinder;

namespace LuigimonORM
{
    /// <summary>
    /// Attribute to define the name of table
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute: Attribute
    {
        /// <summary>
        /// TableAttributte constructor
        /// </summary>
        /// <param name="tableName">Name of table</param>
        public TableAttribute(string tableName, int tablenumber = 0)
        {
            Name = tableName;
            TableNumber = tablenumber;
        }

        /// <summary>
        /// TableAttributte constructor
        /// </summary>
        /// <param name="tableName">Name of table</param>
        public TableAttribute(string tableName)
        {
            Name = tableName;
        }

        /// <summary>
        /// Property name of table
        /// </summary>
        public string Name { get;  set; }

        /// <summary>
        /// Property number of table (use in case of multiple tables select)
        /// </summary>
        /// <value></value>
        public int TableNumber{ set; get; }
  }
}
