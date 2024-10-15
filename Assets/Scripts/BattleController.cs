/*using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public List<BattleEntity> entities; // List of all entities in battle
    private const int speedThreshold = 10000; // Threshold for turn

    void Start()
    {
        // Initialize each entity's speed tracker
        foreach (BattleEntity entity in entities)
        {
            entity.currentSpeed = 0;  // Start at 0 speed
        }
    }

    void Update()
    {
        // Increase speed for each entity and check for turn
        foreach (BattleEntity entity in entities)
        {
            // Increment speed based on entity's speed stat
            entity.currentSpeed += entity.speed * Time.deltaTime;

            // Check if entity has reached or exceeded the speed threshold
            if (entity.currentSpeed >= speedThreshold)
            {
                TakeTurn(entity);
            }
        }
    }

    // Handle the entity's turn
    void TakeTurn(BattleEntity entity)
    {
        Debug.Log(entity.entityName + " takes their turn!");

        // Perform the entity's turn logic here (attack, defend, use items, etc.)
        // For now, just log that they took a turn.

        // Reset their speed using overflow logic (subtract the threshold)
        entity.currentSpeed -= speedThreshold;
    }
}*/
