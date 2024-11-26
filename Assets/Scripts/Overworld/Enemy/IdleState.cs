using System.Collections;
using UnityEngine;

public class IdleState : EnemyState
{
    private float idleTimer;
    private Vector3 idleDirection;

    public IdleState(EnemySeeking enemy) : base(enemy) { }

    public override void EnterState()
    {
        idleTimer = enemy.idleWaitDuration; // Start in idle (waiting)
        idleDirection = Vector3.zero;
    }

    public override void UpdateState()
    {
        idleTimer -= Time.deltaTime;

        if (idleTimer <= 0)
        {
            if (idleDirection == Vector3.zero)
            {
                // Switch to random movement
                idleDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                idleTimer = enemy.idleMoveDuration;
            }
            else
            {
                // Switch back to idle (standing still)
                idleDirection = Vector3.zero;
                idleTimer = enemy.idleWaitDuration;
            }
        }

        // Move in the idle direction
        if (idleDirection != Vector3.zero)
        {
            Vector3 targetPosition = enemy.transform.position + idleDirection * enemy.idleMoveSpeed * Time.deltaTime;
            if (!enemy.IsObstacle(targetPosition))
            {
                enemy.transform.position = targetPosition;
            }
        }

        // Transition to SeekState if the player is in range
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) <= enemy.detectionRange)
        {
            enemy.SwitchState(new SeekState(enemy));
        }
    }

    public override void ExitState() { }
}
