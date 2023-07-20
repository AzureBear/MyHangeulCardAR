using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Sprite[] cardImages; // 이미지 배열, 크기는 2여야 함 (0: correctImage, 1: incorrectImage)

    private void Update()
    {
        HangulGameManager manager = HangulGameManager.instance;
        int[] cardStates = manager.cardStates;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childObject = transform.GetChild(i);
            Image childImage = childObject.GetComponentInChildren<Image>();

            int currentState = cardStates[i];

            // cardStates 배열에 따라 자식 오브젝트의 이미지를 변경
            if (currentState == 1)
            {
                childImage.sprite = cardImages[0]; // 첫 번째 이미지를 사용 (correctImage)
            }
            else if (currentState == 2)
            {
                childImage.sprite = cardImages[1]; // 두 번째 이미지를 사용 (incorrectImage)
            }
            // else: currentState가 0이면 이미지를 그대로 유지 (옵션)
        }
    }
}
