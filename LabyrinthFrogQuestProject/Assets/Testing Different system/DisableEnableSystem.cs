using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableSystem : MonoBehaviour
{
    DialogueSequenceManager dialogueSequenceManager;
    CharacterPusher characterPusher;
    bool isTurnedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSequenceManager = FindObjectOfType<DialogueSequenceManager>();
        characterPusher = FindObjectOfType<CharacterPusher>();

        dialogueSequenceManager.GetComponent<RectTransform>().localPosition = new Vector3(9999, 9999, 9999); // Disable the DialogueSequenceManager
    }

    // Update is called once per frame
    void Update()
    {
        if (characterPusher.dialogueIndex % 10 != 0 && isTurnedOn == true)
        {
            dialogueSequenceManager.GetComponent<RectTransform>().localPosition = new Vector3(9999, 9999, 9999); // Disable the DialogueSequenceManager
            isTurnedOn = false;
        }

        if (characterPusher.dialogueIndex % 10 == 0 && characterPusher.dialogueIndex > 1 && isTurnedOn == false)
        {

            dialogueSequenceManager.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0); // Disable the DialogueSequenceManager


            dialogueSequenceManager.DoOnce();
            isTurnedOn = true;

        }
    }
}
