using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attributes : Attributes
{
    public static AnimCon mAnimCon;

    private void Start() {
        mAnimCon = new AnimCon(GetComponent<Animator>());
    }
}
