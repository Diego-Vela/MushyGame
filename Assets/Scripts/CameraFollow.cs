using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //Has the player object
    public Vector3 offset;   //Offset distance between the player and camera

    void LateUpdate()
    {
        // Update the camera's position based on the player's position and the offset
        transform.position = player.position + offset;
    }
}
