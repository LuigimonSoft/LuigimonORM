using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace LuigimonORM
{
  public class Entity: DataBase
  {
    private ITableNameResolver _tableNameResolver = new TableNameResolver();
    private IColumnNameResolver _columnNameResolver = new ColumnNameResolver();

    private string TableName { get; set; }
    private List<string> ColumnNames { get; set; }
    private string KeyColumn { get; set; }

    public Entity(DataBaseType dialect, string connectionString): base(dialect, connectionString)
    {
      TableName = getTableName(this);
      KeyColumn = getKeyColumnName(this);
      ColumnNames = getColumnsNames();
      
    }

    #region Get Attributes
    private static IEnumerable<PropertyInfo> getPropertyKey(Type type)
    {
      var tp = type.GetProperties().Where(p => p.GetCustomAttributes(true).Any(attr => attr.GetType().Name == typeof(KeyAttribute).Name)).ToList();
      return tp.Any() ? tp : type.GetProperties().Where(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase));
    }

    private static IEnumerable<PropertyInfo> getPropertyKey(object entity)
    {
      var type = entity.GetType();
      return getPropertyKey(type);
    }
    private static string getKeyColumnName(object entity)
    {
      var type = entity.GetType();
      return getPropertyKey(type).First().Name;
    }

    public string getTableName(Type type)
    {
      return _tableNameResolver.ResolveTableName(type, _encapsulation);
    }

    private string getTableName(object entity)
    {
      var type = entity.GetType();
      return getTableName(type);
    }

    private string getColumnName(PropertyInfo propertyInfo, out bool isMapColumn)
    {
      isMapColumn = false;
      //string columnName, key = string.Format("{0}.{1}", propertyInfo.DeclaringType, propertyInfo.Name);
      return _columnNameResolver.ResolveColumnName(propertyInfo, _encapsulation ,out isMapColumn);
    }

    private List<string> getColumnsNames()
    {
      var type = this.GetType();
      List<PropertyInfo> properties = type.GetProperties().Where(p => p.GetCustomAttributes(true).Any(attr => attr.GetType().Name == typeof(ColumnAttribute).Name)).ToList();
      List<string> columnNames = new List<string>();
      foreach (PropertyInfo propertyInfo in properties)
      {
        string columnName = getColumnName(propertyInfo, out bool isMapColumn);
        if (!isMapColumn)
          columnNames.Add(columnName);
      }
      return columnNames;
    }

    #endregion
  }
}