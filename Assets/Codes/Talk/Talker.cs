using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.EventSystems;

public class Talker : MonoBehaviour
{
    GameObject TalkingUI;
    GameObject ReplyUI;
    [SerializeField] CamControl camControl;
    [SerializeField] GameObject reply_Button;
    [SerializeField] bool touchStart;
    [SerializeField] bool followingTalker;


    // Talking content variables
    Text content;
    [SerializeField] string[] talkScript = new string[1];
    [SerializeField] string[] replyScipt = new string[1];
    [SerializeField] Sprite[] replySprite = new Sprite[1];
    int talkScriptIndex;
    int talkLength;
    int replyLength;
    Talker mtalker;
    int optionChose;
    ReplyAction replyAction;
    EventSystem mEventSystem;


    //animation
    public leanAnimation LA;
    public Image shade;
    public GameObject maintalk;
    bool isAnimating;
    public mainTalkAnimation TA;

    void Start()
    {
        TalkingUI = transform.Find("Talk").gameObject;
        ReplyUI = transform.Find("Reply").gameObject;
        content = transform.Find("Talk").transform.Find("Text").gameObject.GetComponent<Text>();
        mEventSystem = EventSystem.current;
        hideUI();
        contentinit();

        replyAction = GetComponent<ReplyAction>();

        //animation
        LeanTween.scale(maintalk, new Vector3(0,0.5f,1), 1f);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")){
            if(TalkingUI.active){
                hideUI();
                camControl.setTalkerActive(false);
                if (isAnimating)
                {
                    isAnimating = false;
                    Resettalkbox();
                }
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
                    Debug.Log("start maintalk "+isAnimating);
                    ShowAnimation();
                }
               
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(touchStart){
            if(other.gameObject.tag == "Player"){
                showUI();
            }
        }

    }

    public void showUI(){
        TalkingUI.SetActive(true);
        ModeControl.mode_Talking = true;
        if(!followingTalker){
            // TODO: automatically change the follow/Lookat to the transform of the talker
            // CamDirector.transform.Find("vcamTalker").GetComponent<>
            camControl.setTalkerActive(true);
        }
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

        for (int i = 0; i < replyLength; i++){
            int b = i;
            GameObject newOption;
            Text text;
            Transform image;
            newOption = Instantiate(reply_Button, ReplyUI.transform);
            newOption.transform.position = new Vector3(newOption.transform.position.x,newOption.transform.position.y + (replyLength*100/2 - 100*i), 0);
            // newOption.GetComponent<Button>().OnSelect(null);
            text = newOption.transform.Find("Text").gameObject.GetComponent<Text>();
            image = newOption.transform.Find("Image");
            text.text = replyScipt[i];
            image.GetComponent<Image>().overrideSprite = replySprite[i];
            newOption.GetComponent<Button>().onClick.AddListener(delegate {ButtonClicked(b); });
            newOption.GetComponent<Button>().onClick.AddListener(delegate { Resettalkbox(); });
            newOption.GetComponent<Button>().onClick.AddListener(delegate { Resetmaintalk(); });
        }
    }

    void showReply(){
        ReplyUI.SetActive(true);

        // For select by keyboard or joystick
        GameObject firstButton = transform.Find("Reply/replyOption(Clone)").gameObject;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton);
        // firstButton.GetComponent<Button>().OnSelect(null);
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
        if(replyAction != null){

            if(replyAction.nextMove(option) < 0){
                // No following talker needed, switch back to the main camera
                camControl.setTalkerActive(false);
                ModeControl.mode_Talking = false;
                hideUI();
            }else{
                // following talker, No need to switch camera
                hideUI();
            }
        }else{
            // No reply action script attached, whole conversation end
            camControl.setTalkerActive(false);
            ModeControl.mode_Talking = false;
            hideUI();
        }
	}

    void ShowAnimation()
    {
        isAnimating = true;
        //animation
        Debug.Log("show reply");
        LeanTween.alpha(shade.rectTransform, 0.9f, 0.5f);
        LeanTween.scale(maintalk, new Vector3(1, 1, 1), 0.1f).setDelay(0.2f);
        LeanTween.scale(maintalk, new Vector3(1, 1, 1), 0.1f).setDelay(0.5f).setOnComplete(startMainAnimation);

    }

    void startMainAnimation()
    {
        TA.startanimation();
    }

    private void Resetmaintalk()
    {
        Debug.Log("reset maintalk");
        LeanTween.scale(maintalk, new Vector3(0, 0.5f, 1), 1f);
        isAnimating = false;
        
    }

    private void Resettalkbox()
    {
        LA.resetanimation();
    }
}
