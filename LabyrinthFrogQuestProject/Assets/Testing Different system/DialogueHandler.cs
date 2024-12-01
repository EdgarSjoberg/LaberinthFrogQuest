using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using System.Collections;

public class DialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // UI TextMeshPro component where dialogue is displayed

    private bool isTyping = false;

    void Start()
    {
        // Nothing special for this part yet, just use the assigned TextMeshProUGUI component.
    }

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
        }

        // Once all lines are done, wait for the Tab key input to move to the next dialogue file or the next part of the game
        FindObjectOfType<DialogueSequenceManager>().WaitForInput();  // Trigger input handling
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

        // Wait for player input to move to the next line
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftShift)); // Wait for Space key input
    }
}
