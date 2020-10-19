using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainTalkAnimation : MonoBehaviour
{
    static Animator animator;
    public static AnimCon mAnimCon;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mAnimCon = new AnimCon(animator);
    }

    public void startanimation()
    {
        mAnimCon.changeAnim("isMaintalking", true);
    }
}
