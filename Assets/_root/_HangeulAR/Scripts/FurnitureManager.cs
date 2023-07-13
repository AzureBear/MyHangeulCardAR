using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public Transform PlacementTarget;
    public void PlaceFurniture(GameObject furniturePrefab)
    {
        GameObject furniture = Instantiate(furniturePrefab, PlacementTarget.position, PlacementTarget.rotation);
    }
}
