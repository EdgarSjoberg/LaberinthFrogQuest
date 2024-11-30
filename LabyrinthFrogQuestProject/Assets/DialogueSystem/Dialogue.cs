using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // The TextMeshPro component that displays the text
    public float textSpeed = 0.05f;       // Speed of text typing

    private string[] currentLines;        // Current lines from the current sequence file
    private int currentLineIndex = 0;     // Track which line we are currently displaying
    private bool isTyping = false;        // Flag to check if we are still typing

    private Sequence sequenceManager;     // Reference to the Sequence class

    void Start()
    {
        // Get the reference to the Sequence script
        sequenceManager = FindObjectOfType<Sequence>();
        textComponent.text = string.Empty;  // Clear text at the start
    }

    public void StartDialogue()
    {
        // Get the lines for the current dialogue from the Sequence class
        currentLines = sequenceManager.GetCurrentFileLines();

        // Debug log to check if lines are loaded correctly
        if (currentLines != null && currentLines.Length > 0)
        {
            Debug.Log($"Loaded {currentLines.Length} lines for dialogue.");
            currentLineIndex = 0;  // Reset line index
            textComponent.text = string.Empty;  // Clear the text field
            StartCoroutine(TypeLine(currentLines[currentLineIndex]));  // Start typing the first line
        }
        else
        {
            Debug.LogError("No lines available to start dialogue.");
        }
    }

    void Update()
    {
        // When the player presses space, either skip to the next line or continue typing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // If we are still typing, skip to the full line
                StopAllCoroutines();
                textComponent.text = currentLines[currentLineIndex];
                isTyping = false;
            }
            else
            {
                // Move to the next line in the dialogue
                NextLine();
            }
        }
    }

    // Coroutine to type out each character in the line
    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        textComponent.text = string.Empty;

        foreach (char letter in line.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;  // Stop typing once the full line is displayed
    }

    // Move to the next line of dialogue
    void NextLine()
    {
        if (currentLines != null && currentLineIndex < currentLines.Length)
        {
            currentLineIndex++;

            if (currentLineIndex < currentLines.Length)
            {
                // Display the next line
                StartCoroutine(TypeLine(currentLines[currentLineIndex]));
            }
            else
            {
                // If we've reached the end of the lines, move to the next file
                EndDialogue();
            }
        }
        else
        {
            Debug.LogWarning("No more lines to display.");
        }
    }

    // End the current dialogue and go to the next file
    void EndDialogue()
    {
        textComponent.text = string.Empty;
        sequenceManager.NextFile(); // Move to the next dialogue file in the sequence
        gameObject.SetActive(false); // Optionally deactivate the dialogue UI
    }
}
