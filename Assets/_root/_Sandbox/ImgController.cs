using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImgController : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager m_TrackedImageManager;

    public List<GameObject> cardPrefabs; // List of card prefabs

    private Dictionary<string, GameObject> ARObjects = new Dictionary<string, GameObject>();

    private bool isTracking = false;

    void Awake()
    {
        foreach (var cardPrefab in cardPrefabs)
        {
            ARObjects.Add(cardPrefab.name, cardPrefab);
        }
    }

    private void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

  
    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // If we are not currently tracking an image
        if (!isTracking)
        {
            // Iterate through all new detected images
            foreach (var newImage in eventArgs.added)
            {
                if (ARObjects.TryGetValue(newImage.referenceImage.name, out GameObject ARObject))
                {
                    GameObject newARObject = Instantiate(ARObject, newImage.transform.position, newImage.transform.rotation);
                    newARObject.transform.SetParent(newImage.transform);

                    // Set isTracking to true as we are now tracking an image
                    isTracking = true;
                    break; // Break from the loop as we only want to track one image at a time
                }
            }
        }

        // If we are currently tracking an image
        else
        {
            // Iterate through all images that are no longer detected
            foreach (var removedImage in eventArgs.removed)
            {
                if (ARObjects.TryGetValue(removedImage.referenceImage.name, out GameObject ARObject))
                {
                    // If the removed image is the one we were tracking
                    if (ARObject.transform.parent == removedImage.transform)
                    {
                        ARObject.SetActive(false);

                        // Set isTracking to false as we are no longer tracking an image
                        isTracking = false;
                        break; // Break from the loop
                    }
                }
            }
        }
    }
}
