using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public Transform ptgt;
    public void PlaceFurniture(GameObject furniturePrefab)
    {
        GameObject fur = Instantiate(furniturePrefab, ptgt.position, ptgt.rotation);
    }
}
