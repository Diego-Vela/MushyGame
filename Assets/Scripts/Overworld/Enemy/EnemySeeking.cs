using System.Collections.Generic;
using UnityEngine;

public class EnemySeeking : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public string obstacleTag = "Mass"; // Tag for obstacles
    public float speed = 2f; // Movement speed
    public float idleMoveSpeed = 1f; // Speed for idle movement
    public float idleMoveDuration = 2f; // Duration of random movement
    public float idleWaitDuration = 3f; // Duration of idle (standing still)
    public float detectionRange = 5f; // Range to detect the player
    public float nodeSpacing = 1f; // Spacing for virtual nodes in world space
    public float heuristicMultiplier = 1.5f; // Multiplier for the heuristic
    public AStarPathfinding pathfinding;

    private EnemyState currentState;

    void Start()
    {
    pathfinding = new AStarPathfinding(nodeSpacing, heuristicMultiplier, obstacleTag);
    SwitchState(new IdleState(this));
    }

    void Update()
    {
        currentState?.UpdateState();
    }

    public void SwitchState(EnemyState newState)
    {
        currentState?.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    public bool IsObstacle(Vector3 position)
    {
        Collider2D hit = Physics2D.OverlapCircle(position, nodeSpacing / 2f);
        return hit != null && hit.CompareTag(obstacleTag);
    }

    public List<Vector3> FindPath(Vector3 startPosition, Vector3 targetPosition)
    {
        // Call the A* algorithm from the pathfinding utility
        return pathfinding.FindPath(startPosition, targetPosition);
    }
}
