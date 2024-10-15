using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    private Button attackButton; // Reference to the attack button
    private Button healButton; // Reference to the heal button
    private Button runButton; // Reference to the run button

    public delegate void ActionChosenHandler(int actionKey); // Modify event to pass an action key
    public static event ActionChosenHandler OnActionChosen;

    private void Start()
    {
        // Find buttons by their name
        attackButton = GameObject.Find("Attack").GetComponent<Button>();
        healButton = GameObject.Find("Heal").GetComponent<Button>();
        runButton = GameObject.Find("Run").GetComponent<Button>();

        // Add listeners to the buttons
        attackButton.onClick.AddListener(() => OnAttackButton());
        healButton.onClick.AddListener(() => OnHealButton());
        runButton.onClick.AddListener(() => OnRunButton());
    }

    public void OnAttackButton()
    {
        Debug.Log("Player chose to attack!");

        // Notify listeners (BattleController) and pass action key '0' for attack
        OnActionChosen?.Invoke(0); // '0' represents attack
    }

    public void OnHealButton()
    {
        Debug.Log("Player chose to heal!");

        // Notify listeners and pass action key '1' for heal
        OnActionChosen?.Invoke(1); // '1' represents heal
    }

    public void OnRunButton()
    {
        Debug.Log("Player chose to run!");

        // Notify listeners and pass action key '2' for run
        OnActionChosen?.Invoke(2); // '2' represents run
    }
}
