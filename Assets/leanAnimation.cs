using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leanAnimation : MonoBehaviour
{
    public bool isMoving = false;
    static Animator animator;
    public static AnimCon mAnimCon;
    // Start is called before the first frame update
    void Awake()
    {
        LeanTween.scale(gameObject, new Vector3(0.3f, 1, 1), 0.75f);
        Debug.Log("prepare");
        animator = GetComponent<Animator>();
        mAnimCon = new AnimCon(animator);
    }

    public void appear()
    {
        Debug.Log("appear");
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.18f).setOnComplete(startanimation);
    }

    void startanimation()
    {
        mAnimCon.changeAnim("isMoving", true);
    }

    public void resetanimation()
    {
        Debug.Log("talkbox reset");
        LeanTween.scale(gameObject, new Vector3(0.3f, 1, 1), 0.75f);
    }
}
