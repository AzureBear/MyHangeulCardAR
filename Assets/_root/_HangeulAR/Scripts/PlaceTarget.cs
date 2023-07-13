using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceTarget : MonoBehaviour
{
    ARRaycastManager rcm;
    GameObject placeTarget;
    private void Start()
    {
        rcm = FindAnyObjectByType<ARRaycastManager>();
        placeTarget = this.transform.GetChild(0).gameObject;
        placeTarget.SetActive(false);
    }

    private void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rcm.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        if (hits.Count > 0 )
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            if(!placeTarget.activeInHierarchy)
            {
                placeTarget.SetActive(true);
            }
        }
    }
}
