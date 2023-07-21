using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class HangulGameManager : MonoBehaviour
{
    public static HangulGameManager instance;
    public static HangeulGame queryGame;
    public static timerbar tb;
    public static MoveToQuery[] QueryContainer = new MoveToQuery[14];
    public TextMeshProUGUI leftText;

    public int[] cardStates = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public int leftCards = 14;

    public GameObject timeBar;
    public GameObject canvasResult;
    public GameObject canvasMenu;
    public GameObject canvasCardScan;
    public GameObject canvasQuery;
    public GameObject canvasStauts;


    //public GameObject arDectectiong;
    public Dictionary<string, GameObject> menus = new Dictionary<string, GameObject>();
    void Awake()
    {
        queryGame = canvasQuery.GetComponent<HangeulGame>();
        tb = timeBar.GetComponent<timerbar>();

        if (instance == null) HangulGameManager.instance = this;
        else Destroy(gameObject);

        menus.Add("menu", canvasMenu);
        menus.Add("result", canvasResult);
        menus.Add("card", canvasCardScan);
        menus.Add("query", canvasQuery);
        
       // menus.Add("ar", arDectectiong);

    }
    void Start()
    {
        MeuSelect("menu");
    }

    public void MeuSelect(string menu)
    {
        foreach (string key in menus.Keys)
        {
            menus[key].SetActive(false);
        }
        if (menu != "ar")
        menus[menu].SetActive(true);
    }

    public void CardCall(int res, int winros)
    {
        if (leftCards != 0)
        {
            leftCards--;
            cardStates[res] = winros;
            if (leftCards == 0)
            {
                
                menus["result"].SetActive(true);
                
                canvasResult.GetComponent<ResultManager>().Finale(cardStates);
            }
        }
        leftText.text = $"남은카드수 {leftCards}";
    }

    public void ResetAll()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
