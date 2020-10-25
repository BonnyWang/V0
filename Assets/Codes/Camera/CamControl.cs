using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    GameObject vcamMain;
    GameObject vcamTalker;
    void Start()
    {
        vcamMain = transform.Find("vcamMain").gameObject;
        vcamTalker = transform.Find("vcamTalker").gameObject;

    }

    void Update()
    {
        
    }
    public void setTalkerActive(bool state){
        if(state){
            vcamMain.SetActive(false);
            vcamTalker.SetActive(true);
        }else{
            vcamTalker.SetActive(false);
            vcamMain.SetActive(true);
        }
    }
}
