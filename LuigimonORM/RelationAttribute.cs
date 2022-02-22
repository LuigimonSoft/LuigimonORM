using System;

namespace LuigimonORM
{
  /// <summary>
  /// RelationAttribute is used to define a relation between two tables.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class RelationAttribute : Attribute
  {
    /// <summary>
    /// RelationAttribute Constructor
    /// </summary>
    public RelationAttribute() { }

    /// <summary>
    /// RelationAttribute Constructor
    /// </summary>
    /// <param name="relation"></param>
    /// <param name="foreignKey"></param>
    /// <param name="tableNumber"></param>
    public RelationAttribute(string relation, string foreignKey, int tableNumber = 0){
      this.Relation = relation;
      this.ForeignKey = foreignKey;
      this.TableNumber = tableNumber;
    }

    public string Relation { get; set; }
    public string ForeignKey { get; set; }
    public int TableNumber { get; set; }
  }
}