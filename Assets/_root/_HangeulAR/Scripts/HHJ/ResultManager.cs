using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Image[] cardImages;
    public Sprite incorrectImg;
    public void Finale(int[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i] == 2)
                cardImages[i].sprite = incorrectImg;
        }
    }

}
