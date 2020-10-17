using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    [SerializeField] GameObject TalkingUI;
    void Start()
    {
        TalkingUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            if(TalkingUI.active){
                TalkingUI.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        TalkingUI.SetActive(true);
    }
}
