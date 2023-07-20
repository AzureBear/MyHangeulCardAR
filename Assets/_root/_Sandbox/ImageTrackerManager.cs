using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackerManager : MonoBehaviour
{
    public HangulGameManager hgm;
    public List<GameObject> ObjectsToPlace;
    public int refImageCount;
    public Dictionary<string, GameObject> allObjects;
    public ARTrackedImageManager arTrackedImageManager;
    private IReferenceImageLibrary refImageLibrary;
    public Texture correctTexture;
    public Texture inCorrectTexture;




    private void Update()
    {
        MapToCheck();
    }

    void MapToCheck()
    {
        foreach (GameObject go in allObjects.Values)
        {
            if (go.activeInHierarchy)
            {
                int cardIndex = int.Parse(go.name);
                int cardState = hgm.cardStates[cardIndex];
                if (cardState == 1)
                    go.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", correctTexture);
                else if (cardState == 2)
                    go.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", inCorrectTexture);
            }
        }
    }

    void LoadObjectDictionary()
    {
        allObjects = new Dictionary<string, GameObject>();
        for (int i = 0; i < refImageCount; i++)
        {
            GameObject newOverlay = new GameObject();
            newOverlay = ObjectsToPlace[i];
            if (ObjectsToPlace[i].gameObject.scene.rootCount == 0)
            {
                newOverlay = (GameObject)Instantiate(ObjectsToPlace[i], transform.localPosition, Quaternion.identity);
            }
            newOverlay.name = newOverlay.name.Replace("(Clone)", "");
            allObjects.Add(refImageLibrary[i].name, newOverlay);
            newOverlay.SetActive(false);
        }
    }

    private void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }
    private void Start()
    {
        refImageLibrary = arTrackedImageManager.referenceLibrary;
        refImageCount = refImageLibrary.count;
        LoadObjectDictionary();
    }
    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var addedImage in args.added)
        {
            ActivateTrackedObject(addedImage.referenceImage.name);
        }
        foreach(var updatedImage in args.updated)
        {
            UpdateTrackedObject(updatedImage);
        }
        foreach(var trackedImage in args.removed)
        {
            Destroy(trackedImage.gameObject);
        }
    }

    void ActivateTrackedObject(string imageName)
    {
        allObjects[imageName].SetActive(true);
    }

    void UpdateTrackedObject(ARTrackedImage trackedImage)
    {
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            allObjects[trackedImage.referenceImage.name].SetActive(true);
            allObjects[trackedImage.referenceImage.name].transform.position = trackedImage.transform.position;
            allObjects[trackedImage.referenceImage.name].transform.rotation = trackedImage.transform.rotation;

        } 
        else
        {
            allObjects[trackedImage.referenceImage.name].SetActive(false);
        }
    }
}
