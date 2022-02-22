using System;

namespace LuigimonORM
{
  public interface ITableNameResolver
  {
    string ResolveTableName(Type type, string _encapsulation);
  }
}