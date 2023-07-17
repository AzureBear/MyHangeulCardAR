using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultiTrackingSystem : MonoBehaviour
{
    public ARTrackedImageManager imageMan;

    public GameObject[] Consofabs;


    void Start()
    {
        imageMan.trackedImagesChanged += OnTrackedImg;
    }

    void OnTrackedImg(ARTrackedImagesChangedEventArgs args)
    {

        foreach(ARTrackedImage trackedImage in args.added)
        {
            GameObject Gam = Consofabs[1];
        }

        foreach(ARTrackedImage trackedImage in args.updated)
        {
            if(trackedImage.transform.childCount > 0)
            {
                trackedImage.transform.GetChild(0).position = trackedImage.transform.position;
                trackedImage.transform.GetChild(0).rotation = trackedImage.transform.rotation;
                trackedImage.transform.GetChild(0).localScale = trackedImage.transform.localScale;

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
