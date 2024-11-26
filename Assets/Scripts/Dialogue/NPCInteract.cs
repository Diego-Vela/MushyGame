using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel; // The dialogue UI panel
    public GameObject npcObject; // Set the parent GameObject (the NPC object)
    public GameObject interactMarker; // Show sign that says interaction
    public DialogueData npcDialogue; // Object containing dialogue data for NPC
    public Texture2D image; // Reference to set sprite to dialogue
    public RawImage setActor; // Reference to Actor 2 to set image
    private bool isPlayerInRange; // To check if player is in the interaction zone
    public int currentDialogueIndex = 0; // Track which dialogue line we're on
    protected bool isCompanion;
    protected string characterName;
    

    void Start()
    {
        dialoguePanel.SetActive(false);
        interactMarker.SetActive(false);
        characterName = transform.parent.gameObject.name;
    }

    void Update()
    {
        
        // Check for interaction input (Space key) and if player is in range
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            InteractWithNPC();
        }
    }

    // Mark this method as virtual to allow overriding in subclasses
    protected virtual void InteractWithNPC()
    {
        prepareDialogue();
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
    public virtual void UpdateDialogueText(string newDialogue)
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
            //Debug.Log("Player is in an InteractionZone");
            interactMarker.SetActive(true);
            isPlayerInRange = true;  // Player is now in the interaction zone
        }
    }

    // Detect when the player leaves the trigger collider (interaction zone)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (interactMarker == null || dialoguePanel == null)
            return;
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("Player left an InteractionZone");
            interactMarker.SetActive(false);
            isPlayerInRange = false;  // Player is no longer in the interaction zone
            dialoguePanel.SetActive(false);  // Hide the dialogue panel if the player walks away
            currentDialogueIndex = 0;        // Reset dialogue index when player leaves
        }
    }

    public virtual void deactivateNPC()
    {        
        // Deactivate NPC
        npcObject.SetActive(false);
        // Debug Statement
        Debug.Log("Parent NPC has been deactivated.");
        // Change map state
    }

    public void prepareDialogue()
    {
        setActor.texture = image;
        interactMarker.SetActive(false);
    }
}
