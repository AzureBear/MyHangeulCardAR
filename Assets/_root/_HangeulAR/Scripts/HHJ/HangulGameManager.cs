using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangulGameManager : MonoBehaviour
{
    public static HangulGameManager instance;

    public GameObject canvasResult;
    public GameObject canvasMenu;
    public GameObject canvasCardScan;
    public GameObject canvasQuery;
    //public GameObject arDectectiong;
    public Dictionary<string, GameObject> menus = new Dictionary<string, GameObject>();
    void Awake()
    {
        if (instance == null) HangulGameManager.instance = this;
        else Destroy(gameObject);

        menus.Add("menu", canvasMenu);
        menus.Add("result", canvasResult);
        menus.Add("card", canvasCardScan);
        menus.Add("query", canvasQuery);
       // menus.Add("ar", arDectectiong);
    }
    public void MeuSelect(string menu)
    {
        foreach (string key in menus.Keys)
        {
            menus[key].SetActive(false);
        }
        if(menu != "ar")
        menus[menu].SetActive(true);
    }

    void Start()
    {
        MeuSelect("menu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
