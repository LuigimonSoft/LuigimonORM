using System;

namespace LuigimonORM
{
  /// <summary>
  /// Attibute to define column  
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class ColumnAttribute : Attribute
  {
    private int _maximumlength=-1;
    private int _minimumlength=-1;

    public ColumnAttribute()
    {
    }

    public ColumnAttribute(string columnName)
    {
      Name = columnName;
    }
    /// <summary>
    /// Name of column
    /// </summary>
    public string Name { get; private set; }

    public bool isNullable { get;  set;}

    public int MaximumLength {
      set { _maximumlength = value; }
      get { return _maximumlength; }
    }

    public int MinimumLength
    {
      set { _minimumlength=value; }
      get { return _minimumlength; }
    }

    public string RegexPattern { get; set; }

    public bool AllowEmpty{ get;  set;}

    public string ErrorNullMessage { get; set; }
    public string ErrorEmptyMessage { get; set; }
    public string ErrorMaximunMessage { get; set; }
    public string ErrorminimumMessage { get; set; }
    public string ErrorRegexMessage { get; set; }
  }
}