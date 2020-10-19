using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leanAnimation : MonoBehaviour
{
    public bool isMoving = false;
    static Animator animator;
    public static AnimCon mAnimCon;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(0, 1, 1), 1f);
        animator = GetComponent<Animator>();
        mAnimCon = new AnimCon(animator);
    }

    public void appear()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.18f).setOnComplete(startanimation);
    }

    void startanimation()
    {
        mAnimCon.changeAnim("Ismoving", true);
    }
}
