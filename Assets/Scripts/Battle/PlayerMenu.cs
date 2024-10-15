using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMenu : MonoBehaviour
{
    private Button attackButton; // Reference to the attack button
    private Button healButton; // Reference to the heal button
    private Button runButton; // Reference to the run button

    public GameObject selectedEntity; // The entity that will take damage or be healed

    private void Start()
    {
        // Find buttons by their name
        attackButton = GameObject.Find("Attack").GetComponent<Button>();
        healButton = GameObject.Find("Heal").GetComponent<Button>();
        runButton = GameObject.Find("Run").GetComponent<Button>();

        // Add listeners to the buttons
        attackButton.onClick.AddListener(Attack);
        healButton.onClick.AddListener(Heal);
        runButton.onClick.AddListener(Run);
    }

    // Attack method - Calls the TakeDamage function on the selected entity
    private void Attack()
    {
        if (selectedEntity != null)
        {
            selectedEntity.GetComponent<BattleEntity>().TakeDamage(50); // Example damage value of 50
        }
        else
        {
            Debug.LogError("No entity selected to attack.");
        }
    }

    // Heal method - Heals the selected entity based on intelligence stat
    private void Heal()
    {
        if (selectedEntity != null)
        {
            selectedEntity.GetComponent<BattleEntity>().Heal(20);
        }
        else
        {
            Debug.LogError("No entity selected to heal.");
        }
    }

    // Run method - Returns to the "HomeTown" scene
    private void Run()
    {
        SceneManager.LoadScene("HomeTown"); // Load the HomeTown scene
    }
}
