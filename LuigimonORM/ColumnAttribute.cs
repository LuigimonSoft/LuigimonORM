using System;

namespace LuigimonORM
{
  /// <summary>
  /// Attibute to define column  
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class ColumnAttribute : Attribute
  {
    private int _maximumlength = -1;
    private int _minimumlength = -1;

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

    public bool isNullable { get; set; }

    /// <summary> 
    /// Property to define maximum length of column
    /// </summary>
    public int MaximumLength
    {
      set { _maximumlength = value; }
      get { return _maximumlength; }
    }

    public int MinimumLength
    {
      set { _minimumlength = value; }
      get { return _minimumlength; }
    }

    public string RegexPattern { get; set; }

    /// <summary>
    /// property to allow empty string
    /// </summary>
    public bool AllowEmpty { get; set; }

    public string ErrorNullMessage { get; set; }
    public string ErrorEmptyMessage { get; set; }
    public string ErrorMaximunMessage { get; set; }
    public string ErrorminimumMessage { get; set; }
    public string ErrorRegexMessage { get; set; }

    /// <summary>
    /// Property to ignore column in an select query
    /// </summary>
    public bool IgnoreInSelect { get; set; }
    /// <summary>
    /// Property to ignore column in an insert query
    /// </summary>
    public bool IgnoreInInsert { get; set; }
    /// <summary>
    /// Property to ignore column in an update query
    /// </summary>
    public bool IgnoreInUpdate { get; set; }
    /// <summary>
    /// Property to ignore column in an delete query
    /// </summary>
    public bool IgnoreInDelete { get; set; }
  }
}