using System;
using System.Reflection;

namespace LuigimonORM
{
  public interface IColumnNameResolver
  {
    string ResolveColumnName(PropertyInfo propertyInfo, string _encapsulation,out bool MapColumn);
  }
}