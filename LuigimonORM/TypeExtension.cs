using System;
using System.Collections.Generic;
internal static class TypeExtension
{
  public static bool isSimpleType(this Type type)
  {
    var underlyingType = Nullable.GetUnderlyingType(type);
    type = underlyingType ?? type;
    var simpleType = new List<Type>
    {
          typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(bool),
            typeof(string),
            typeof(char),
            typeof(Guid),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(byte[])

    };
    return simpleType.Contains(type) || type.IsEnum;
  }
}