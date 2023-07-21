using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HangulGameManager : MonoBehaviour
{
    public static HangulGameManager instance;
    public static HangeulGame queryGame;
    public static timerbar tb;
    public static GameObject sc;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI deb;

    public int[] cardStates = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    private bool gameClear = false;
    public int leftCards = 14;

    public GameObject timeBar;
    public GameObject canvasResult;
    public GameObject canvasMenu;
    public GameObject canvasCardScan;
    public GameObject canvasQuery;
    public GameObject statusCan;
    //public GameObject arDectectiong;
    public Dictionary<string, GameObject> menus = new Dictionary<string, GameObject>();
    void Awake()
    {
        queryGame = canvasQuery.GetComponent<HangeulGame>();
        tb = timeBar.GetComponent<timerbar>();
        sc = statusCan;

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

    public void CardCall(int res, int winros)
    {
        if (leftCards != 0)
        {
            sc.SetActive(true);
            leftCards--;
            leftText.text = $"남은카드수 {leftCards}";
            cardStates[res] = winros;
            if (leftCards == 0)
            {
                sc.SetActive(false);
                menus["result"].SetActive(true);
                canvasResult.GetComponent<ResultManager>().Finale(cardStates);
            }
        }
    }

    void Start()
    {
        MeuSelect("menu");
    }
    void Update()
    {
        deb.text = $"{cardStates[0]},{cardStates[1]},{cardStates[2]},{cardStates[3]},{cardStates[4]},{cardStates[5]},{cardStates[6]},{cardStates[7]},{cardStates[8]},{cardStates[9]},{cardStates[10]},{cardStates[11]},{cardStates[12]},{cardStates[13]}";
    }
}
