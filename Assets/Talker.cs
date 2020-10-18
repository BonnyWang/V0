using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talker : MonoBehaviour
{
    [SerializeField] GameObject TalkingUI;

    // Talking content variables
    Text content;
    [SerializeField] string[] sentence = new string[1];
    int sentenceIndex;
    int length;
   
    void Start()
    {
        TalkingUI.SetActive(false);
        Time.timeScale = 1;

        content = transform.Find("Talk").transform.Find("Text").gameObject.GetComponent<Text>();
        contentinit();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            if(TalkingUI.active){
                hideUI();
            }
        }

        if(Input.GetButtonDown("Submit")&& gameObject.active){
            if(sentenceIndex < (length-1)){
                // Display next sentence
                sentenceIndex++;
                content.text = sentence[sentenceIndex];
            }else{
                hideUI();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        showUI();
    }

    void showUI(){
        TalkingUI.SetActive(true);
        Time.timeScale = 0;
        contentinit();
    }

    void hideUI(){
        TalkingUI.SetActive(false);
        Time.timeScale = 1;
    }

    void contentinit(){
        sentenceIndex = 0;
        length = sentence.Length;
        content.text = sentence[sentenceIndex];
    }
}
