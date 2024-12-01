using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableSystem : MonoBehaviour
{
    DialogueSequenceManager dialogueSequenceManager;
    CharacterPusher characterPusher;
    bool isTurnedOn = false;

    Vector3 moveAwayPos;
    [SerializeField] Vector3 screenPos;

    // Start is called before the first frame update
    void Start()
    {
        dialogueSequenceManager = FindObjectOfType<DialogueSequenceManager>();
        characterPusher = FindObjectOfType<CharacterPusher>();

        moveAwayPos = new Vector3(9999, 9999, 9999);
        //screenPos = new Vector3(0, -600, 0);
        dialogueSequenceManager.GetComponent<RectTransform>().localPosition = moveAwayPos; // Disable the DialogueSequenceManager
    }

    // Update is called once per frame
    void Update()
    {
        if (characterPusher.dialogueIndex % 10 != 0 && isTurnedOn == true)
        {           

            dialogueSequenceManager.GetComponent<RectTransform>().localPosition = moveAwayPos; // Disable the DialogueSequenceManager
            isTurnedOn = false;
        }

        if (characterPusher.dialogueIndex % 10 == 0 && characterPusher.dialogueIndex > 1 && isTurnedOn == false)
        {
            

            dialogueSequenceManager.GetComponent<RectTransform>().localPosition = screenPos; // Disable the DialogueSequenceManager


            dialogueSequenceManager.DoOnce();
            isTurnedOn = true;

        }
    }
}
