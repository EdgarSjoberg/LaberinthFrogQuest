using UnityEngine;
using System.IO;

public class DialogueSequenceManager : MonoBehaviour
{
    public string dialogueFolderPath = "Assets/Dialogue"; // Folder path where the text files are stored
    public float textSpeed = 0.05f; // Speed of text appearing letter by letter
    public bool isSingleFileDialogue = false; // Toggle between single file or multiple files

    private string[] dialogueFiles;
    private int currentDialogueIndex = 0;
    private DialogueHandler dialogueHandler;

    string[] lines;
    CharacterPusher characterPusher;
    public bool readOnce = false;

    void Start()
    {
        characterPusher = FindObjectOfType<CharacterPusher>();

        // Load all the text files from the specified folder
        dialogueFiles = Directory.GetFiles(dialogueFolderPath, "*.txt");

        // Ensure we have at least one file
        if (dialogueFiles.Length > 0)
        {
            dialogueHandler = FindObjectOfType<DialogueHandler>(); // Get the DialogueHandler instance in the scene

            if (isSingleFileDialogue)
            {
                LoadSingleDialogue(dialogueFiles[currentDialogueIndex]); // Load the first file if it's a single file dialogue
            }
            else
            {
                LoadDialogue(dialogueFiles[currentDialogueIndex]); // Load the first file in multiple file scenario
            }
        }
        else
        {
            Debug.LogError("No dialogue files found in folder.");
        }
    }

    // Loads all the lines from a single text file
    void LoadSingleDialogue(string filePath)
    {
        lines = File.ReadAllLines(filePath);

    }

    // Loads a dialogue text file and sends it to the DialogueHandler
    void LoadDialogue(string filePath)
    {
        lines = File.ReadAllLines(filePath);
    }

    // Call this method to progress to the next dialogue file (if multiple file dialogue is enabled)
    public void NextDialogue()
    {
        if (isSingleFileDialogue)
        {
            Debug.Log("Single-file dialogue, no further files.");
            return; // No progression for single file dialogue
        }

        currentDialogueIndex++;
        if (currentDialogueIndex < dialogueFiles.Length)
        {
            LoadDialogue(dialogueFiles[currentDialogueIndex]);
        }
        else
        {
            Debug.Log("End of dialogue sequence.");
            // Optionally, trigger some game progression, like enabling player movement or starting new events
        }
    }
    private void Update()
    {
        if (characterPusher.dialogueIndex == 10 && readOnce == false)
        {
            DoOnce();
        }
    }

    public void DoOnce()
    {
        if (characterPusher.dialogueIndex > 0 && characterPusher.dialogueIndex % 10 == 0)
        {
            WaitForInput();
            dialogueHandler.StartDialogue(lines, textSpeed);
            readOnce = true;
        }
    }

    // New method to handle Tab key progression
    public void WaitForInput()
    {
        // Wait for key to switch to the next dialogue file



        // Check if there's another dialogue file to load
        if (currentDialogueIndex + 1 < dialogueFiles.Length)
        {
            currentDialogueIndex++;
            LoadSingleDialogue(dialogueFiles[currentDialogueIndex]);
        }
        else
        {
            Debug.Log("End of dialogue files.");
            readOnce = false;
        }


        // Check for 'Q' to progress to the next game event or dialogue sequence

    }
}
