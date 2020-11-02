using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    protected GameObject player;
    public virtual void castElement() {}
    public virtual void showDirection(){
        Detector.getInputDirection(transform);
    }

    private void Awake() {
        player = GameObject.Find("Player");
    }


}
