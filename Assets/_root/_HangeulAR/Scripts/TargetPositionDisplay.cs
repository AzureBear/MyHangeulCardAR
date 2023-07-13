using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetPositionDisplay : MonoBehaviour
{
    public GameObject trgt;
    public TextMeshProUGUI tpostxt;

    void Update()
    {
        if (trgt.activeInHierarchy)
        {
            tpostxt.text = "(" + trgt.transform.position + ")";
        }
    }
}
