using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementControl : MonoBehaviour
{
    public bool canUse;
    ParticleSystem particleSystem;
    
    private void Start() {
        canUse = true;
        particleSystem = transform.Find("PS").GetComponent<ParticleSystem>();
    }
    public void usedElement(){
        canUse = false;
        StartCoroutine(reActive());
        particleSystem.Clear();
    }

    IEnumerator reActive(){
        yield return new WaitForSeconds(15);
        Debug.Log("can be Reuse");
        canUse = true;
        particleSystem.Emit(1);
        particleSystem.Play();
    }
}
