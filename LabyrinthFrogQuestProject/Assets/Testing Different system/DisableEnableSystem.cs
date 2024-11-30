using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableSystem : MonoBehaviour
{
    DialogueSequenceManager dialogueSequenceManager;
    bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q key pressed, progressing to next game sequence or event.");
            // Here you can trigger the next part of your game logic, such as activating new events, loading a new scene, etc.
            // Example:
            // LoadGameProgress();

            isActive = !isActive; // Toggle the DialogueSequenceManager on/off


            dialogueSequenceManager.gameObject.SetActive(isActive); // Disable the DialogueSequenceManager
        }
    }
}
