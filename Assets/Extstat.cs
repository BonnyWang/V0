using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Extstat : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Player_Attributes.ext.ToString();
    }
}
