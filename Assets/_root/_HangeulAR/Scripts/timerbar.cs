using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerbar : MonoBehaviour
{
    public Image timerimage;
    public HangulGameManager hgm;
    public HangeulGame game;
    public float maxTime = 10f;
    private float currentTime;
    private int currentQz;
    public bool isRun = false;

    public void Awake()
    {
        timerimage = GetComponent<Image>();
        if (!timerimage)
        {
            timerimage = transform.Find("Image").GetComponent<Image>();
        }
    }

    public void Update()
    {
        if (isRun)
        {
            currentTime -= Time.deltaTime;
            UpdateTimeBar();
            if (currentTime <= 0f)
            {
                timeOver(currentQz);
                isRun = false;
            }
        }
    }

    public void ReceiveQz(int arg)
    {
        currentTime = maxTime;
        currentQz = arg;
        isRun = true;
    }

    public void timeOver(int curQz)
    {
        game.Bad.Play();
        game.cq.KillOfQz();
        hgm.cardStates[curQz] = 2;
        hgm.leftCards--;
        hgm.leftText.text = $"남은카드수 {hgm.leftCards}";
        game.gameObject.SetActive(false);
    }

    public void UpdateTimeBar()
    {
        float fillAmount = Mathf.Clamp01(currentTime / maxTime);
        timerimage.fillAmount = fillAmount;
    }
}