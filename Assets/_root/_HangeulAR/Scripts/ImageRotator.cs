using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRotator : MonoBehaviour
{
    public int rotSpeed;
   
    void Update()
    {
        Vector3 rotation = new Vector3 (0,45,0) * rotSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }
}
