//using System;
using System.Collections.Generic;
using UnityEngine;

//Contains a cell and a few more pieces of data,
//as well as a function to compare our objects with desired logic
public class CellAnalysis : System.IComparable<CellAnalysis>
{
  [SerializeField]
  public Vector3Int cell;
  public int distToStart;
  public int distToGoal;
  public int totalDist;
  public override string ToString()
  {
    return cell.ToString() + distToStart + " " + distToGoal + " " + totalDist + " ";
  }
  //Implemented so that List.Sort will work with this object
  public int CompareTo(CellAnalysis obj) {
    //A negative value = this precedes obj, 0 = same position, positive = obj precedes this
    int value = totalDist - obj.totalDist;
    //We primarily care about distinction via totalDist, in a common sense influenced order:
    if(value == 0) value = obj.distToGoal - distToGoal;
    if(value == 0) value = obj.distToStart - distToStart;
    //Vector3Ints can't be compared through subtraction, so we simply check for equality
    if(value == 0) value = obj.cell == cell?0:-1;
    return value;
  }
}
