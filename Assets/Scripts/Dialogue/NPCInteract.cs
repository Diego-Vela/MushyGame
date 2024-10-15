using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel; // The dialogue UI panel
    public DialogueData npcDialogue; // Object containing dialogue data for NPC
    private bool isPlayerInRange; // To check if player is in the interaction zone
    public int currentDialogueIndex = 0; // Track which dialogue line we're on
    public LayerMask interactionLayer; // Layer for InteractionZone
    public bool isCompanion;
    public GameObject npcObject; // Set the parent GameObject (the NPC object)

    void Start()
    {
        // Ensure the dialogue panel is hidden at the start
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check for interaction input (Space key) and if player is in range
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithNPC();
        }
    }

    // Mark this method as virtual to allow overriding in subclasses
    protected virtual void InteractWithNPC()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            // Show the next dialogue line, or close the dialogue if it's the last line
            currentDialogueIndex++;
            if (currentDialogueIndex < npcDialogue.dialogueLines.Length)
            {
                UpdateDialogueText(npcDialogue.dialogueLines[currentDialogueIndex]);
            }
            else
            {
                dialoguePanel.SetActive(false);  // Hide the dialogue panel when done
                currentDialogueIndex = 0;       // Reset dialogue index
                if (isCompanion) 
                {
                    deactivateNPC();
                }
            }
        }
        else
        {
            // Start the dialogue if the panel is currently hidden
            dialoguePanel.SetActive(true);
            UpdateDialogueText(npcDialogue.dialogueLines[currentDialogueIndex]);
        }
    }

    // Update the dialogue text in the dialogue panel
    public void UpdateDialogueText(string newDialogue)
    {
        var textComponent = dialoguePanel.GetComponentInChildren<TMPro.TextMeshProUGUI>();

        if (textComponent != null)
        {
            textComponent.text = newDialogue;
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found!");
        }
    }

    // Detect when the player enters the trigger collider (interaction zone)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player is in an InteractionZone");
            isPlayerInRange = true;  // Player is now in the interaction zone
        }
    }

    // Detect when the player leaves the trigger collider (interaction zone)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player left an InteractionZone");
            isPlayerInRange = false;  // Player is no longer in the interaction zone
            dialoguePanel.SetActive(false);  // Hide the dialogue panel if the player walks away
            currentDialogueIndex = 0;        // Reset dialogue index when player leaves
        }
    }

    public void deactivateNPC()
    {        
        // Deactivate NPC
        npcObject.SetActive(false);
        // Debug Statement
        Debug.Log("Parent NPC has been deactivated.");
    }
}
