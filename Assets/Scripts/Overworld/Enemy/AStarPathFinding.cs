using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinding
{
    private float nodeSpacing;
    private float heuristicMultiplier;
    private string obstacleTag;

    public AStarPathfinding(float nodeSpacing, float heuristicMultiplier, string obstacleTag)
    {
        this.nodeSpacing = nodeSpacing;
        this.heuristicMultiplier = heuristicMultiplier;
        this.obstacleTag = obstacleTag;
    }

    public List<Vector3> FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        // Open and closed sets
        List<Vector3> open = new List<Vector3> { startPosition };
        HashSet<Vector3> closed = new HashSet<Vector3>();
        Dictionary<Vector3, Vector3> path = new Dictionary<Vector3, Vector3>();

        // Costs for the A* algorithm
        Dictionary<Vector3, float> aCost = new Dictionary<Vector3, float> { [startPosition] = 0 };
        Dictionary<Vector3, float> eCost = new Dictionary<Vector3, float> { [startPosition] = Heuristic(startPosition, targetPosition) };

        while (open.Count > 0)
        {
            // Get the node with the lowest eCost
            Vector3 current = GetLowestECost(open, eCost);

            // Check if we've reached the target
            if (Vector3.Distance(current, targetPosition) < nodeSpacing)
            {
                return ReconstructPath(path, current);
            }

            open.Remove(current);
            closed.Add(current);

            // Get neighbors
            foreach (Vector3 neighbor in GetNeighbors(current))
            {
                if (closed.Contains(neighbor) || IsObstacle(neighbor))
                    continue;

                float tentativeACost = aCost[current] + Vector3.Distance(current, neighbor);

                if (!open.Contains(neighbor))
                    open.Add(neighbor);
                else if (tentativeACost >= aCost[neighbor])
                    continue;

                // This path is the best so far
                path[neighbor] = current;
                aCost[neighbor] = tentativeACost;
                eCost[neighbor] = aCost[neighbor] + Heuristic(neighbor, targetPosition);
            }
        }

        Debug.Log("No valid path found...");
        return new List<Vector3>(); // Return an empty path if no valid path is found
    }

    private float Heuristic(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b) * heuristicMultiplier;
    }

    private Vector3 GetLowestECost(List<Vector3> open, Dictionary<Vector3, float> eCost)
    {
        Vector3 lowestNode = open[0];
        float lowestScore = eCost[lowestNode];

        foreach (Vector3 node in open)
        {
            if (eCost[node] < lowestScore)
            {
                lowestScore = eCost[node];
                lowestNode = node;
            }
        }

        return lowestNode;
    }

    private List<Vector3> ReconstructPath(Dictionary<Vector3, Vector3> path, Vector3 current)
    {
        List<Vector3> totalPath = new List<Vector3> { current };
        while (path.ContainsKey(current))
        {
            current = path[current];
            totalPath.Add(current);
        }
        totalPath.Reverse();
        return totalPath;
    }

    private List<Vector3> GetNeighbors(Vector3 position)
    {
        List<Vector3> neighbors = new List<Vector3>();
        Vector3[] directions = new Vector3[]
        {
            new Vector3(-nodeSpacing, 0, 0),  // Left
            new Vector3(nodeSpacing, 0, 0),   // Right
            new Vector3(0, -nodeSpacing, 0),  // Down
            new Vector3(0, nodeSpacing, 0)    // Up
        };

        foreach (Vector3 direction in directions)
        {
            Vector3 neighbor = position + direction;
            neighbors.Add(neighbor);
        }
        return neighbors;
    }

    private bool IsObstacle(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, nodeSpacing / 2f);
        return hit != null && hit.CompareTag(obstacleTag);
    }
}
