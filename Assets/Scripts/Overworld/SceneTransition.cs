using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private SceneTransitioner transition; // The name of the scene to transition to using tilemap
    public string targetScene;
    public float x;
    public float y;

    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("SceneTransitioner").GetComponent<SceneTransitioner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the collider is the player
        if (other.CompareTag("Player"))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        transition.TransitionScene(targetScene, new Vector2(x,y));
    }
}
