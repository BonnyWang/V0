using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Opestat : MonoBehaviour
{

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Player_Attributes.ope.ToString();
    }
}
