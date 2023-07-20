using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Sprite[] cardImages; // �̹��� �迭, ũ��� 2���� �� (0: correctImage, 1: incorrectImage)

    private void Update()
    {
        HangulGameManager manager = HangulGameManager.instance;
        int[] cardStates = manager.cardStates;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childObject = transform.GetChild(i);
            Image childImage = childObject.GetComponentInChildren<Image>();

            int currentState = cardStates[i];

            // cardStates �迭�� ���� �ڽ� ������Ʈ�� �̹����� ����
            if (currentState == 1)
            {
                childImage.sprite = cardImages[0]; // ù ��° �̹����� ��� (correctImage)
            }
            else if (currentState == 2)
            {
                childImage.sprite = cardImages[1]; // �� ��° �̹����� ��� (incorrectImage)
            }
            // else: currentState�� 0�̸� �̹����� �״�� ���� (�ɼ�)
        }
    }
}
