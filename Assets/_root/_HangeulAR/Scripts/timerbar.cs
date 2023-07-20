using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerbar : MonoBehaviour
{
    public Image timerimage;
    public HangulGameManager hgm;
    public float maxTime = 30f;
    private float currentTime;
    private int currentQz;

    public void OnEnable()
    {
        currentTime = maxTime;
        timerimage = GetComponent<Image>();
        if (!timerimage)
        {
            timerimage = transform.Find("Image").GetComponent<Image>();
        }

        UpdateTimeBar();
    }

    public void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimeBar();
        }
        else if (currentTime == 0f)
        {
            timeOver(currentQz);
            UpdateTimeBar();
        }
    }

    public void timeOver(int curQz)
    {
        hgm.cardStates[curQz] = 2;
    }

    public void UpdateTimeBar()
    {
        float fillAmount = Mathf.Clamp01(currentTime / maxTime);
        timerimage.fillAmount = fillAmount;
    }

    public void ResetTimer()
    {
        currentTime = maxTime;
        UpdateTimeBar();
    }

    public void SetCurrentTimeToMaxTime()
    {
        currentTime = maxTime;
        UpdateTimeBar();
    }
}