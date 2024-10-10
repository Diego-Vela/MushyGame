using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //Speed of the player movement

    private Vector3 moveDirection;

    void Update()
    {
        //Get input from arrow keys
        float moveX = Input.GetAxisRaw("Horizontal"); //Left and right arrow keys
        float moveY = Input.GetAxisRaw("Vertical");   //Up and down arrow keys

        //Create a movement direction based on input
        moveDirection = new Vector3(moveX, moveY, 0f).normalized;

        //Move the player
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
