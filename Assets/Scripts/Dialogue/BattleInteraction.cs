using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleInteraction : NPCInteraction
{

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
        Debug.Log("Loading battle scene...");
        SceneManager.LoadScene("Battle");  // Load the specified battle scene
    }
}
