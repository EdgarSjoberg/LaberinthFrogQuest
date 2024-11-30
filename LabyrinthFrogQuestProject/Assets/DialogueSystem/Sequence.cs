using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UIElements;


public class Sequence : MonoBehaviour
{
    public int currentSequence = 0;
    TextAsset[] paths;
    string[] texts;
    // Start is called before the first frame update
    void Start()
    {
        paths = Resources.LoadAll<TextAsset>("");
        texts = new string[paths.Length];

        // Populate the texts array with file contents
        for (int i = 0; i < paths.Length; i++)
        {
            texts[i] = paths[i].text;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            if(currentSequence < texts.Length)
            {
                ReadString();
            }
        }

        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
                currentSequence++;
            
        }
    }

    void ReadString()
    {
        string text = texts[currentSequence];
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(text);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}