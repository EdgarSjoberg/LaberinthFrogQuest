using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // UI Text component where dialogue is displayed
    private bool isTyping = false;

    // Start displaying a new dialogue
    public void StartDialogue(string[] lines, float textSpeed)
    {
        StartCoroutine(DisplayDialogue(lines, textSpeed));
    }

    // Coroutine to handle the display of text line by line with typing effect
    private IEnumerator DisplayDialogue(string[] lines, float textSpeed)
    {
        foreach (string line in lines)
        {
            yield return StartCoroutine(TypeText(line, textSpeed));
            
            // Wait for player input to proceed to the next line
            while (!Input.GetKeyDown(KeyCode.Space)) // Or you could use any other input
            {
                yield return null;
            }           
        }

        // Once all lines are done, you can trigger the next dialogue sequence
        FindObjectOfType<DialogueSequenceManager>().NextDialogue();
    }

    // Coroutine that types the text one letter at a time
    private IEnumerator TypeText(string line, float textSpeed)
    {
        dialogueText.text = ""; // Clear previous text
        isTyping = true;

        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }
}
