using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask_Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Substring(0,4) == "Mask"){
            Player_Attributes.wearMask = true;
            Player_Animation.changeAnim("Masked",true);
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.tag == "Mask1"){
            Player_Attributes.attackMode = 1;
            Debug.Log("1");
        }
        if(other.gameObject.tag == "Mask2"){
            Player_Attributes.attackMode = 2;
            Debug.Log("Mask2");

        }
    }
}
