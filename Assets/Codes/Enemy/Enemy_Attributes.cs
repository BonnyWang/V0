using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attributes : Attributes
{
    

    public float relativeDir;

    private void Start() {
        base_Initialization();
        initialzation();

    }

    void initialzation(){
        velocity_H = 2f;
    }

    
}
