﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System.Collections.Generic;

public class Displaytext : MonoBehaviour {

    //an array of UI Text labels you wish to display text on
    public List<GameObject> Screens = new List<GameObject>();

    string text = "";
    int strIndex = 0;
    const float TypingSpeed = 0.010f;
    float deltTime = 0.0f;
    int lineCount = 0;
    const int linesToDisplay = 15;

	// Use this for initialization
	void Start () {
        TextAsset txtasset = (TextAsset)Resources.Load("sched", typeof(TextAsset));
        text = txtasset.text;
    }
	
	// Update is called once per frame
	void Update () {
        deltTime += Time.deltaTime;
        if (deltTime >= TypingSpeed)
        {
            string newText = "";
            //add a character
            strIndex++;
            if (strIndex >= text.Length)
                strIndex = 0;
            newText = Screens[0].GetComponent<Text>().text + text[strIndex];
            if (text[strIndex] == '\n')
                lineCount++;
            while (lineCount >= linesToDisplay)
            {
                newText = trimTopLine(newText);
                lineCount = lineCount - 1;
            }

            //set final new text
            for (int i = 0; i < Screens.Count; i++)
            {
                Screens[i].GetComponent<Text>().text = newText;
            }
        }
        
	}

    int countLines()
    {
        int result = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '\n') result++;
        }
        return result;
    }

    string trimTopLine(string instr)
    {
        for (int i = 0; i < instr.Length; i++)
        {
            if (instr[i] == '\n')
                return instr.Substring(i + 1);
        }
        return "";
    }
}
