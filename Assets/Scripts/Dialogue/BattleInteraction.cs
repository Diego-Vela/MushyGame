using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleInteraction : NPCInteraction
{
    private EnemyCreator enemyCreator;

    // Override the InteractWithNPC method to add battle interaction
    protected override void InteractWithNPC()
    {
        prepareDialogue();
        if (dialoguePanel.activeInHierarchy)
        {
            // Show the next dialogue line, or load battle if it's the last line
            currentDialogueIndex++;
            if (currentDialogueIndex < npcDialogue.dialogueLines.Length)
            {
                UpdateDialogueText(npcDialogue.dialogueLines[currentDialogueIndex]);
            }
            else
            {
                dialoguePanel.SetActive(false);  // Hide the dialogue panel when done
                currentDialogueIndex = 0;       // Reset dialogue index

                // Check if this is a battle NPC
                StartBattle();
            }
        }
        else
        {
            // Start the dialogue if the panel is currently hidden
            dialoguePanel.SetActive(true);
            UpdateDialogueText(npcDialogue.dialogueLines[currentDialogueIndex]);
        }
    }

    // Start a battle by loading the battle scene
    private void StartBattle()
    {
        enemyCreator = GameObject.FindGameObjectWithTag("EnemyCreator").GetComponent<EnemyCreator>();
        
        if (enemyCreator == null)
        {
            Debug.LogWarning("EnemyCreator not found!");
            return;
        }

        enemyCreator.CreateEnemy(transform.parent.gameObject.name, image, SceneManager.GetActiveScene().name);
        //Debug.Log("Loading battle scene...");
        
        SceneTransitioner.instance.SavePosition(GameObject.FindWithTag("Player"));
        SceneManager.LoadScene("Battle");  // Load the specified battle scene
    }
}
