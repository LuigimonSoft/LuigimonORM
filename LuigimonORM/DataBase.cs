using System;

namespace LuigimonORM
{
  public class DataBase
  {
    private DataBaseType _dialect;

    public static string _encapsulation;
    private static string _getIdentitySql;
    private static string _getPagedListSql;

    public string ConnectionString { get; set; }

    public DataBase(DataBaseType dialect,string connectionString)
    {
      _dialect = dialect;
      ConnectionString = connectionString;
    }
    public enum DataBaseType
    {
      SQLServer,
      PostgreSQL,
      SQLite,
      MySQL,
    }

    public DataBaseType TipoBaseDatos
    {
      set
      {
        switch (value)
        {
          case DataBaseType.PostgreSQL:
            _dialect = DataBaseType.PostgreSQL;
            _encapsulation = "\"{0}\"";
            _getIdentitySql = string.Format("SELECT LASTVAL() AS id");
            _getPagedListSql = "Select {SelectColumns} from {TableName} {WhereClause} Order By {OrderBy} LIMIT {RowsPerPage} OFFSET (({PageNumber}-1) * {RowsPerPage})";
            break;
          case DataBaseType.SQLite:
            _dialect = DataBaseType.SQLite;
            _encapsulation = "\"{0}\"";
            _getIdentitySql = string.Format("SELECT LAST_INSERT_ROWID() AS id");
            _getPagedListSql = "Select {SelectColumns} from {TableName} {WhereClause} Order By {OrderBy} LIMIT {RowsPerPage} OFFSET (({PageNumber}-1) * {RowsPerPage})";
            break;
          case DataBaseType.MySQL:
            _dialect = DataBaseType.MySQL;
            _encapsulation = "`{0}`";
            _getIdentitySql = string.Format("SELECT LAST_INSERT_ID() AS id");
            _getPagedListSql = "Select {SelectColumns} from {TableName} {WhereClause} Order By {OrderBy} LIMIT {Offset},{RowsPerPage}";
            break;
          default:
            _dialect = DataBaseType.SQLServer;
            _encapsulation = "[{0}]";
            _getIdentitySql = string.Format("SELECT CAST(SCOPE_IDENTITY()  AS BIGINT) AS [id]");
            _getPagedListSql = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY {OrderBy}) AS PagedNumber, {SelectColumns} FROM {TableName} {WhereClause}) AS u WHERE PagedNUMBER BETWEEN (({PageNumber}-1) * {RowsPerPage} + 1) AND ({PageNumber} * {RowsPerPage})";
            break;
        }
      }
      get { return _dialect; }
    }
  }

}