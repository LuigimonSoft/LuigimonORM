using System;
using System.Linq;

namespace LuigimonORM
{
  public class TableNameResolver : ITableNameResolver
  {
    public virtual string ResolveTableName(Type type,string _encapsulation)
    {
      var tableName = Encapsulate(type.Name,_encapsulation);

      var tableattr = type.GetCustomAttributes(true).SingleOrDefault(attr => attr.GetType().Name == typeof(TableAttribute).Name) as dynamic;
      if (tableattr != null)
      {
        tableName = Encapsulate(tableattr.Name, _encapsulation);
        try
        {
          if (!String.IsNullOrEmpty(tableattr.Schema))
          {
            string schemaName = Encapsulate(tableattr.Schema, _encapsulation);
            tableName = String.Format("{0}.{1}", schemaName, tableName);
          }
        }
        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
        {
          //Schema doesn't exist on this attribute.
        }
      }

      return tableName;
    }

    private static string Encapsulate(string databaseword, string _encapsulation)
    {
      return string.Format(_encapsulation, databaseword);
    }
  }
}