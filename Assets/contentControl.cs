using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class contentControl : MonoBehaviour
{
      [SerializeField] string[] sentence = new string[1];
     int sentenceIndex;
     int length;

     Text textMesh;
    void Start()
    {
    
        sentenceIndex = 0;
        length = sentence.Length;
        textMesh = GetComponent<Text>();
        textMesh.text = sentence[sentenceIndex];
    }

    void Update()
    {
        if(Input.GetButtonDown("Submit")&& gameObject.active){
            if(sentenceIndex < (length-1)){
                sentenceIndex++;
                textMesh.text = sentence[sentenceIndex];
            }else{
                // 
            }
        }
    }
}
