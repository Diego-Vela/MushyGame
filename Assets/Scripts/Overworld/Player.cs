using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region variables
    
    public float moveDuration = 0.01f;  // Duration to move between tiles
    public float tileSize = 16f;       // Size of a tile in pixels
    public LayerMask collisionLayer;   // Set this to the layer that colliders are on
    private bool isMoving;
    private Vector2 input;

    public Animator animator;

    #endregion

    #region unity
    void Start()
    {
        isMoving = false;
    }

    void Update()
    {
        if (!isMoving)
        {
            handleMovement();
        }

        handleAnimation();
    }
    #endregion

    #region movement
    private void handleMovement() {
        // Get input from arrow keys (including diagonal movement)
        input.x = Input.GetAxisRaw("Horizontal");  // 1 for right, -1 for left
        input.y = Input.GetAxisRaw("Vertical");    // 1 for up, -1 for down

        // Allow diagonal movement
        if (input != Vector2.zero)
        {
            StartCoroutine(MovePlayer());
        }
    }

    private IEnumerator MovePlayer()
    {
        isMoving = true;

        // Normalize input for consistent movement speed in diagonal directions
        Vector2 normalizedInput = input.normalized;

        // Calculate target position based on tile size and input direction
        Vector3 targetPosition = transform.position + new Vector3(normalizedInput.x * tileSize / 100, normalizedInput.y * tileSize / 100, 0);

        // Check if there's an obstacle in the target position using OverlapCircle
        if (IsBlocked(targetPosition))
        {
            isMoving = false;
            yield break;  // Stop moving if the path is blocked
        }

        // Store the starting position for smooth movement
        Vector3 startingPosition = transform.position;

        // Initialize a timer to control how long the movement takes
        float elapsedTime = 0f;

        // Move the player smoothly to the target position over `moveDuration`
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;  // Increment timer
            yield return null;
        }

        // Snap player to the exact target position (to avoid overshoot)
        transform.position = targetPosition;

        isMoving = false;
    }

    // Check if the target position is blocked by a collider
    private bool IsBlocked(Vector3 targetPosition)
    {
        // Use Physics2D.OverlapCircle to check if there's a collider in the target tile
        // Reduce the radius to a smaller value (0.05f) to check a small area around the player
        Collider2D hit = Physics2D.OverlapCircle(targetPosition, 0.5f, collisionLayer);
        return hit != null;
    }
    #endregion

    #region animation
    private void handleAnimation() {
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);
        animator.SetFloat("Speed", input.sqrMagnitude);
    }
    #endregion

    #region save

    public void Save()
    {
        GameState gamestate = GameObject.FindWithTag("GameState").GetComponent<GameState>();
        Party party = GameObject.FindWithTag("Party").GetComponent<Party>();
        string sceneName = SceneManager.GetActiveScene().name;

        SaveSystem.Save(this, gamestate, party, sceneName);
    }

    public void SetPosition(float x, float y)
    {
        transform.position = new Vector2(x,y);
        Debug.Log("Player position loaded: " + transform.position);
    }
    
    #endregion
}
