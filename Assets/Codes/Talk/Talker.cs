using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talker : MonoBehaviour
{
    GameObject TalkingUI;
    GameObject ReplyUI;
    [SerializeField] GameObject reply_Button;


    // Talking content variables
    Text content;
    [SerializeField] string[] talkScript = new string[1];
    [SerializeField] string[] replyScipt = new string[1];
    int talkScriptIndex;
    int talkLength;
    int replyLength;
    Talker mtalker;
    int optionChose;

    //ITEM & STAT
    [SerializeField] Backpack mbackpack;
    public Player_Attributes PA;
    [SerializeField] public itemstat[] itemgiven = new itemstat[100];

    //animation
    public leanAnimation LA;
    public Image shade;
    public GameObject maintalk;
    bool isAnimating;

    void Start()
    {
        TalkingUI = transform.Find("Talk").gameObject;
        ReplyUI = transform.Find("Reply").gameObject;
        content = transform.Find("Talk").transform.Find("Text").gameObject.GetComponent<Text>();
        hideUI();
        contentinit();

        //animation
        LeanTween.scale(maintalk, new Vector3(0,0.5f,1), 1f);


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
            if(talkScriptIndex < (talkLength-1)){
                // Display next talkScript
                talkScriptIndex++;
                content.text = talkScript[talkScriptIndex];
            }
            else if(TalkingUI.active)
            {

                showReply();
                if (!isAnimating)
                {
                    ShowAnimation();
                }
               
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        showUI();
    }

    void showUI(){
        TalkingUI.SetActive(true);
        LA.appear();
        //Time.timeScale = 0;

        talkScriptIndex = 0;
        content.text = talkScript[talkScriptIndex];
    }

    void hideUI(){
        TalkingUI.SetActive(false);
        Time.timeScale = 1;
        hideReply();
    }

    void contentinit(){
        talkScriptIndex = 0;
        talkLength = talkScript.Length;
        replyLength = replyScipt.Length;
        content.text = talkScript[talkScriptIndex];
        



        for (int i = 0; i < replyLength; i++)
        {
            GameObject newOption;
            Text text;
            newOption = Instantiate(reply_Button, ReplyUI.transform);
            newOption.transform.position = new Vector3(newOption.transform.position.x,newOption.transform.position.y + (replyLength*100/2 - 100*i), 0);
            text = newOption.transform.Find("Text").gameObject.GetComponent<Text>();
            text.text = replyScipt[i];
            int a = i;
            newOption.GetComponent<Button>().onClick.AddListener(delegate {ButtonClicked(a); });
            

        }
    }

    void showReply(){
        ReplyUI.SetActive(true);


    }
    void timestop()
    {
        Time.timeScale = 0;
        Debug.Log("timestop");
    }
    void hideReply(){
        ReplyUI.SetActive(false);
    }

    void ButtonClicked(int option){
		optionChose = option;
        Debug.Log("option " + option);
        //emo
        if (optionChose == 0)
        {
            PA.changeFace(1, 5);
        }
        //relic
        if (optionChose == 1)
        {
            mbackpack.addObject(itemgiven[0]);
            PA.changeFace(1, itemgiven[0].emo);
            PA.changeFace(2, itemgiven[0].con);
            PA.changeFace(3, itemgiven[0].ext);
            PA.changeFace(4, itemgiven[0].ope);
            PA.changeFace(5, itemgiven[0].hon);
            PA.changeFace(6, itemgiven[0].agr);
        }
        hideUI();
	}

    void ShowAnimation()
    {
        isAnimating = true;
        //animation
        Debug.Log("show reply");
        LeanTween.alpha(shade.rectTransform, 0.8f, 0.5f);
        LeanTween.scale(maintalk, new Vector3(1, 1, 1), 0.1f);
        LeanTween.scale(maintalk, new Vector3(1, 1, 1), 0.1f).setDelay(0.5f).setOnComplete(timestop);
    }
}
