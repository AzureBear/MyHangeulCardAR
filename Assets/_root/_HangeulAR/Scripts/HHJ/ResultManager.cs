using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Image[] cardImages;
    public Sprite incorrectImg;
    public HangulGameManager status;
    public void Finale(int[] elements)
    {
        status.canvasStauts.SetActive(false);
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i] == 2)
                cardImages[i].sprite = incorrectImg;
        }
    }

}
