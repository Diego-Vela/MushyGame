using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "NPC/Dialogue")]
public class DialogueData : ScriptableObject
{
    [TextArea(2, 5)]
    public string[] dialogueLines;
}
