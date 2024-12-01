using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sequence : MonoBehaviour
{
    public int currentSequence = 0; // Track the current sequence (file index)
    private string[][] allTexts;    // Store lines from all text files (2D array)
    private string[] currentLines;  // Store lines for the current sequence file

    void Start()
    {
        LoadTextFiles();  // Load the files when the game starts
    }

    // Load all text files from the Resources folder
    void LoadTextFiles()
    {
        // Load all text assets in the "sentences" folder inside Resources
        TextAsset[] paths = Resources.LoadAll<TextAsset>("sentences");

        if (paths.Length == 0)
        {
            Debug.LogError("No text files found in the Resources/sentences folder!");
            return;
        }

        allTexts = new string[paths.Length][]; // Initialize the 2D array to hold all lines

        // Split each text file into lines
        for (int i = 0; i < paths.Length; i++)
        {
            allTexts[i] = paths[i].text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);

            // Log how many lines were loaded from each file
            Debug.Log($"Loaded {allTexts[i].Length} lines from file {i}: {paths[i].name}");
        }

        Debug.Log($"Total files loaded: {allTexts.Length}");
    }

    // Get the current lines for the dialogue sequence
    public string[] GetCurrentFileLines()
    {
        // Check if we have a valid file to load
        if (currentSequence < allTexts.Length)
        {
            currentLines = allTexts[currentSequence]; // Get lines for the current sequence

            // Log the current lines loaded for debugging
            Debug.Log($"Returning {currentLines.Length} lines from sequence {currentSequence}");
            return currentLines;
        }
        else
        {
            Debug.LogError("No more files available.");
            return null;
        }
    }

    // Move to the next sequence
    public void NextFile()
    {
        currentSequence++;

        // Check if we've reached the end of the files
        if (currentSequence >= allTexts.Length)
        {
            Debug.LogWarning("No more dialogues available.");
        }
        else
        {
            Debug.Log($"Moving to next file: {currentSequence}");
        }
    }
}
