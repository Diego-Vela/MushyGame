using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    private Button attackButton; // Reference to the attack button
    private Button healButton; // Reference to the heal button
    private Button runButton; // Reference to the run button

    // Reference to the BattleController
    public BattleController battleController;

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
        // Debug.Log("Attack pressed");
        battleController.ActionChosen(0); // '0' represents attack
    }

    public void OnHealButton()
    {
        //Debug.Log("heal pressed");
        battleController.ActionChosen(1); // '1' represents heal
    }

    public void OnRunButton()
    {
        //Debug.Log("run pressed");
        battleController.ActionChosen(2); // '2' represents run
    }
}
