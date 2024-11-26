//You will be making your own class, using your own name
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//Make sure you rename both your file and your class!
public class DiegoVela : AstarBase 
{
  protected Tilemap _obstacles;

  public override List<Vector3Int> CalculatePath(Vector3 curWorldPos, Vector3 clickedMousePos, Tilemap obstacles)
  {
    Debug.Log("CalculatePath has been called:"+curWorldPos+clickedMousePos);
    // Make it faster
    Time.timeScale = 5f;

    // Obstacles
    _obstacles = obstacles;
    // Starting cell for our algorithm
    Vector3Int curTile = obstacles.WorldToCell(curWorldPos);
    // Destination cell for our algorithm
    Vector3Int clickedTile = obstacles.WorldToCell(clickedMousePos);

    return findPath(curTile, clickedTile);
  }

  // Method to find the AStart path
  private List<Vector3Int> findPath(Vector3Int curTile, Vector3Int clickedTile)
  {     
    // Open and closed lists for A* algorithm
    List<Vector3Int> open = new List<Vector3Int> { curTile };
    HashSet<Vector3Int> closed = new HashSet<Vector3Int>();
    Dictionary<Vector3Int, Vector3Int> path = new Dictionary<Vector3Int, Vector3Int>();

    // Costs for the A* algorithm, let aCost be the actual cost and eCost be the expected
    Dictionary<Vector3Int, float> aCost = new Dictionary<Vector3Int, float> { [curTile] = 0 };
    Dictionary<Vector3Int, float> eCost = new Dictionary<Vector3Int, float> { [curTile] = Heuristic(curTile, clickedTile) };

    //Loop
    while (open.Count > 0)
    {
      // Get the current node with the lowest eCost
      Vector3Int current = getLowestECost(open, eCost);

      // Check if we have reached the clickedTile
      if (current == clickedTile)
      {
        return getPath(path, current);
      }

      open.Remove(current);
      closed.Add(current);

      // Get neighbors
      foreach (Vector3Int neighbor in GetNeighbors(current))
      {
        // Do not calculate if already visited or if it's an obstacle
        if (closed.Contains(neighbor) || IsObstacle(neighbor))
          continue;
        
        float tentativeACost = aCost[current] + 1;
        // Add neightbor to open if not already in it.
        if (!open.Contains(neighbor))
            open.Add(neighbor);
        // Continue if this is not a better path
        else if (tentativeACost >= aCost[neighbor])
          continue; 

      // This path is the best until now
      path[neighbor] = current;
      aCost[neighbor] = tentativeACost;
      eCost[neighbor] = aCost[neighbor] + Heuristic(neighbor, clickedTile);
      }
    }
    // Empty list if no path found
    Debug.Log("No valid path found...");
    return new List<Vector3Int>();
  }

  // Heuristic function using Manhattan distance
  private float Heuristic(Vector3Int a, Vector3Int b)
  {
      return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
  }

  // Method to get the node with the lowest eCost from the open set
  private Vector3Int getLowestECost(List<Vector3Int> open, Dictionary<Vector3Int, float> eCost)
  {
      Vector3Int lowestNode = open[0];
      float lowestScore = eCost[lowestNode];

      foreach (Vector3Int node in open)
      {
          if (eCost[node] < lowestScore)
          {
              lowestScore = eCost[node];
              lowestNode = node;
          }
      }
      return lowestNode;
  }
  // Method to reconstruct the path from curTile to clickedTile
  private List<Vector3Int> getPath(Dictionary<Vector3Int, Vector3Int> path, Vector3Int current)
  {
      List<Vector3Int> totalPath = new List<Vector3Int> { current };
      while (path.ContainsKey(current))
      {
          current = path[current];
          totalPath.Add(current);
      }
      return totalPath;
  }
  
  // Method to get the neighbors of a given cell
  private List<Vector3Int> GetNeighbors(Vector3Int cell)
  {
    List<Vector3Int> neighbors = new List<Vector3Int>();
    
    // Get the 4 directions
    Vector3Int[] directions = new Vector3Int[]
    {
        new Vector3Int(-1, 0, 0), // Left
        new Vector3Int(1, 0, 0),  // Right
        new Vector3Int(0, -1, 0), // Down
        new Vector3Int(0, 1, 0)   // Up
    };

    // Add neighbors to the list
    foreach (Vector3Int direction in directions)
    {
        Vector3Int neighbor = cell + direction;
          neighbors.Add(neighbor);
    }
    
    return neighbors;
  }

  // Check if a cell is an obstacle
  private bool IsObstacle(Vector3Int cell)
  {
      // Check if the cell is filled in the obstacles tilemap
      return _obstacles.HasTile(cell);
  }
}