using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class contentControl : MonoBehaviour
{
     string[] sentence;
     int sentenceIndex;
     int length;

     Text textMesh;
    void Start()
    {
        sentence[0] = "Hello, idiot!";
        sentence[1] = "Let me guide you";
        sentenceIndex = 0;
        length = sentence.Length;
        textMesh = GetComponent<Text>();
        Debug.Log(textMesh.text);
        textMesh.text = sentence[sentenceIndex];
    }

    void Update()
    {
        if(Input.GetButtonDown("Submit")){
            if(sentenceIndex < (length-1)){
                sentenceIndex++;
                textMesh.text = sentence[sentenceIndex];
            }
        }
    }
}
