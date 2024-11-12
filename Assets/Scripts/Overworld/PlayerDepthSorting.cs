using UnityEngine;

public class PlayerDepthSorting : MonoBehaviour
{
    private SpriteRenderer playerRenderer;

    void Start()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Adjust sorting order based on the player's Y position
        playerRenderer.sortingOrder = (int)(-transform.position.y * 100);
    }
}
