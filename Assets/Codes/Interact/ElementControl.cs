using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementControl : MonoBehaviour
{
    public bool canUse;
    ParticleSystem particleSystem;
    [SerializeField] float coolingTime;
    
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
        yield return new WaitForSeconds(coolingTime);
        Debug.Log("can be Reuse");
        canUse = true;
        particleSystem.Emit(1);
        particleSystem.Play();
    }
}
