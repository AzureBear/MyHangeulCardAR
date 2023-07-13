using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetPositionDisplay : MonoBehaviour
{
    public GameObject target;
    public TextMeshProUGUI targetPositionText;

    void Update()
    {
        if (target.activeInHierarchy)
        {
            targetPositionText.text = "(" + targetPositionText.transform.position + ")";
        }
    }
}
