﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Emostat : MonoBehaviour
{
 
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Player_Attributes.emo.ToString();
    }
}
