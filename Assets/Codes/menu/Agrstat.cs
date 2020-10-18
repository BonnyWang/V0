using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Agrstat : MonoBehaviour
{

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Player_Attributes.agr.ToString();
    }
}
