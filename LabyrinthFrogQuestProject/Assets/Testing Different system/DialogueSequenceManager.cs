using UnityEngine;
using System.IO;
using System.Collections;

public class DialogueSequenceManager : MonoBehaviour
{
    public string dialogueFolderPath = "Assets/Dialogue"; // Folder path where the text files are stored
    public float textSpeed = 0.05f; // Speed of text appearing letter by letter

    private string[] dialogueFiles;
    private int currentDialogueIndex = 0;
    private DialogueHandler dialogueHandler;

    void Start()
    {
        // Load all the text files from the specified folder
        dialogueFiles = Directory.GetFiles(dialogueFolderPath, "*.txt");

        // Ensure we have at least one file
        if (dialogueFiles.Length > 0)
        {
            dialogueHandler = FindObjectOfType<DialogueHandler>(); // Get the DialogueHandler instance in the scene
            LoadDialogue(dialogueFiles[currentDialogueIndex]);
        }
        else
        {
            Debug.LogError("No dialogue files found in folder.");
        }
    }

    // Loads a dialogue text file and sends it to the DialogueHandler
    void LoadDialogue(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        dialogueHandler.StartDialogue(lines, textSpeed);
    }

    // Call this method to progress to the next dialogue file
    public void NextDialogue()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogueFiles.Length)
        {
            LoadDialogue(dialogueFiles[currentDialogueIndex]);
        }
        else
        {
            Debug.Log("End of dialogue sequence.");
            // Optionally, trigger some game progression, like enabling player movement
        }
    }
}
