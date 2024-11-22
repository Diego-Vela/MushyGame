using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class EventTextBoxController : MonoBehaviour
{
    public TextMeshProUGUI eventText; // Reference to the TextMeshPro component
    private float typingSpeed = .02f; // Time between each letter
    public GameObject playerGuide; // Reference to the guide

    private void Start() {
        playerGuide.SetActive(false);        
    }

    public IEnumerator Test() {
            Debug.Log("HI");
            for (int i = 0; i < 5; i ++) {
                yield return StartCoroutine(LogEvent("Testing a relatively large but not too large message for testing purposes as a test test." + i));
            }
    }

    public IEnumerator LogEvent(string message)
    {
        yield return StartCoroutine(TypeMessage(message));
    }

    public IEnumerator LogActionEvent(string message)
    {
        yield return StartCoroutine(TypeActionMessage(message));
    }

    private IEnumerator TypeMessage(string message)
    {
        eventText.text = ""; // Clear text box

        // Type each letter with a delay
        foreach (char letter in message)
        {
            eventText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
        playerGuide.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
        playerGuide.SetActive(false);
    }

        private IEnumerator TypeActionMessage(string message)
    {
        eventText.text = ""; // Clear text box

        // Type each letter with a delay
        foreach (char letter in message)
        {
            eventText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
