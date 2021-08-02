using System;
using System.Reflection;
using System.Linq;

namespace LuigimonORM
{
  public class ColumnNameResolver : IColumnNameResolver
  {
    public virtual string ResolveColumnName(PropertyInfo propertyInfo, string _encapsulation,out bool MapColumn)
    {
      MapColumn = false;
      var columnName = Encapsulate(propertyInfo.Name, _encapsulation);

      var columnattr = propertyInfo.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == typeof(ColumnAttribute).Name) as dynamic;
      if (columnattr != null)
      {
        if (!String.IsNullOrEmpty(columnattr.Name))
        {
          MapColumn = true;
          columnName = Encapsulate(columnattr.Name, _encapsulation);
          if (System.Diagnostics.Debugger.IsAttached)
            System.Diagnostics.Trace.WriteLine(String.Format("Column name for type overridden from {0} to {1}", propertyInfo.Name, columnName));
        }
      }
      return columnName;
    }

    private static string Encapsulate(string databaseword, string _encapsulation)
    {
      return string.Format(_encapsulation, databaseword);
    }
  }
}