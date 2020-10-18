using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Honstat : MonoBehaviour
{

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Player_Attributes.hon.ToString();
    }
}
