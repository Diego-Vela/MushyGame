using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player; //Has the player object
    public Vector3 offset;   //Offset distance between the player and camera

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // Update the camera's position based on the player's position and the offset
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

    }
}
