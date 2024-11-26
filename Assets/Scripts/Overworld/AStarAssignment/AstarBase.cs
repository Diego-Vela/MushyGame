using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


/// <summary>
/// Used by students to define a class that implements astar pathfinding for use in this demo
/// </summary>
public class AstarBase : MonoBehaviour
{
  //Note: List<T> noDupes = withDupes.Distinct().ToList();
  //Above code will help strip out any duplicates from your list
  //Otherwise you can use listname.Sort to sort your list. 
  
  //I recommend that you make use of the CellAnalysis class to help store 
  //information required for calculating the A-star path. GridNavigator will use
  //the list you create in order to move through points on the map, this can
  //also be used through the inspector.

  /// <summary>
  /// Calculates a path from curWorldPos to the center of the cell containing clickedMousePos.
  /// This function must be implemented, though you have the choice of implementing others.
  /// </summary>
  /// <param name="curWorldPos">Current world position of the controlled object</param>
  /// <param name="clickedMousePos">World space coordinates of the mouse coordinates</param>
  /// <param name="obstacles">Used to determine cell positions, and whether a particular cell is a valid location</param>
  /// <returns>List of Vector3Int representing each step in the path from the player 
  /// to the destination. Note the GridNavigator class needs it organized such that 
  /// the next cell to travel to is in the last index in our List. This can be 
  /// generated from the inputs.</returns>


  //Virtual function: By inheriting from the AstarBase class, you can provide your own definition
  //Focus on the process:
  //1. Select available node with cheapest cost
  //2. Calculate cost of all its neighboring nodes, check for goal
  //2b. While discarding duplicates and only selecting unexpanded nodes
  public virtual List<Vector3Int> CalculatePath(Vector3 curWorldPos, Vector3 clickedMousePos, Tilemap obstacles)
  {
    //Starting cell for our algorithm
    Vector3Int curTile = obstacles.WorldToCell(curWorldPos);
    //Destination cell for our algorithm
    Vector3Int clickedTile = obstacles.WorldToCell(clickedMousePos);
    
    List<Vector3Int> path = new List<Vector3Int>();
    //path gets filled here
    return path;
  }
}