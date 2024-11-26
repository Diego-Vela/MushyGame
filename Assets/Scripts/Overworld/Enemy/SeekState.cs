using System.Collections.Generic;
using UnityEngine;
public class SeekState : EnemyState
{
    private List<Vector3> path;
    private int pathIndex;

    public SeekState(EnemySeeking enemy) : base(enemy) { }

    public override void EnterState()
    {
        path = enemy.pathfinding.FindPath(enemy.transform.position, enemy.player.position);
        pathIndex = 0;
    }

    public override void UpdateState()
    {
        if (pathIndex < path.Count)
        {
            Vector3 targetNode = path[pathIndex];
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetNode, enemy.speed * Time.deltaTime);

            if (Vector3.Distance(enemy.transform.position, targetNode) <= 0.1f)
            {
                pathIndex++;
            }
        }

        // Recalculate path periodically or if the player moves significantly
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) > enemy.detectionRange)
        {
            enemy.SwitchState(new IdleState(enemy)); // Switch back to idle if the player is out of range
        }
    }

    public override void ExitState() { }
}
