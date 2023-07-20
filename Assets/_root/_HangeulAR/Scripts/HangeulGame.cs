using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;
using Unity.VisualScripting;

public class HangeulGame : MonoBehaviour
{
    public ImageTrackerManager imgTrkMan;
    public HangulGameManager manager;
    public ToggleGroup toggleGroup;
    public Toggle[] toggles = new Toggle[4];
    public GameObject dev;

    private int currentCard;

    /*
    public Dictionary<string, int> cards = new Dictionary<string, int>()
    {
        {"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },
        {"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 }
    };
    */

    public string answer;
    public string [,] answers =
    {
       {"�����", "���"}, {"����", "�ʱ���" }, {"�ٶ���", "����"},{ "���", "����" }, {"����", "����" }, {"����", "��ѱ�" }, {"����", "������" },
       { "����", "����" }, {"�ڵ���", "����ö"},{ "�౸", "ġ��" },{"�ڳ���", "ī�޶�"},{ "�䳢", "�±ر�"},{"����", "���ξ���"},{"ȣ����", "�б�"}
    };


    // ����ī�帶�� 4������ 2������ �߰�
    public Dictionary<int, List<string[]>> questions = new Dictionary<int, List<string[]>>
    {
        {0, new List<string[]>()
        {
            new string[] {"�����", "������", "����", "������"},
            new string[] {"���", "����", "���", "����"}
        } },
        {1, new List<string[]>
        {
            new string[] {"����", "�ʺ�", "����", "����"},
            new string[] {"�ʱ���", "����", "�ʰ�", "�ϱ���"}
        } },
        {2, new List<string[]>
        {
            new string[] {"�ٶ���", "����", "�ٷ���", "�ٶ���"},
            new string[] {"����", "����", "����", "����"}
        } },
        {3, new List<string[]>
        {
            new string[] {"���", "����", "����", "����"},
            new string[] {"����", "����", "������", "�����"}
        } },
        {4, new List<string[]>
        {
            new string[] {"����", "����", "����", "����"},
            new string[] {"����", "�յ�", "�ε�", "����"}
        } },
        {5, new List<string[]>
        {
            new string[] {"����", "����", "����", "����"},
            new string[] {"��ѱ�", "��ѱ�", "�񵹱�", "�����"}
        } },
        {6, new List<string[]>
        {
            new string[] {"����", "����", "����", "�ҹ�"},
            new string[] {"������", "�ջ���", "������", "������"}
        } },
        {7, new List<string[]>
        {
            new string[] {"����", "����", "���", "����"},
            new string[] {"����", "�߱�", "����", "����"}
        } },
        {8, new List<string[]>
        {
            new string[] {"�ڵ���", "�ڼ���", "������", "������"},
            new string[] {"����ö", "ġ��ö", "������", "ġ����"}
        } },
        {9, new List<string[]>
        {
            new string[] {"�౸", "�˱�", "����", "����"},
            new string[] {"ġ��", "����", "ġ��", "����"}
        } },
        {10, new List<string[]>
        {
            new string[] {"�ڳ���", "�ڱ���", "������", "���ٸ�"},
            new string[] {"ī�޶�", "Ű�޶�", "�ɹ���", "ť�޶�"}
        } },
        {11, new List<string[]>
        {
            new string[] {"�䳢", "����", "�γ�", "�볢"},
            new string[] {"�±ر�", "���س�", "�뱹��", "���س�"}
        } },
        {12, new List<string[]>
        {
            new string[] {"����", "��", "�ε�", "����"},
            new string[] {"���ξ���", "���ο���", "�������", "�����غ�"}
        } },
        {13, new List<string[]>
        {
            new string[] {"ȣ����", "�����", "ȭ����", "ȸ����"},
            new string[] {"�б�", "�ٱ�", "����", "Ȯ��"}
        } },

    };




    private void Start()
    {

    }
    private void OnEnable()
    {
        // SetupButtons();
    }

    public void OnButtonClick(int fs, int sc)
    {
        if (manager.cardStates[fs] == 0)
        {
            List<string[]> questionList = questions[fs];
            string[] questionChoices = questionList[sc];

            // ������ �迭�� �����ϱ� ���� ���� ����
            answer = answers[fs, sc];
            currentCard = fs;

            // ������ �迭�� ����
            string[] shuffledChoices = ShuffleChoices(questionChoices);

            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].GetComponentInChildren<TextMeshProUGUI>().text = shuffledChoices[i];
                toggles[i].group = toggleGroup;
                toggles[i].isOn = false;
            }
        }
        else
            dev.SetActive(true);

    }

    public void CheckAnswer()
    {
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn)
            {
                //imgTrkMan.EndOfCard(currentCard);
                string selectedAnswer = toggle.GetComponentInChildren<TextMeshProUGUI>().text;
                if (selectedAnswer == answer)
                {
                    manager.CardCall(currentCard, 1);
                    //manager.cardStates[currentCard] = 1;
                    this.gameObject.SetActive(false);

                }
                else
                {
                    manager.CardCall(currentCard, 1);
                    //manager.cardStates[currentCard] = 2;
                    this.gameObject.SetActive(false);
                }
                break;
            }
        }
    }



    public string[] ShuffleChoices(string[] choices)
    {
        System.Random rng = new System.Random();
        int n = choices.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = choices[k];
            choices[k] = choices[n];
            choices[n] = value;
        }

        return choices;
    }


}
