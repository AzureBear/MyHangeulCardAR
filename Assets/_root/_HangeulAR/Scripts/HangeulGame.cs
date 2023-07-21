using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;
using Unity.VisualScripting;
using System.Xml.Linq;

public class HangeulGame : MonoBehaviour
{
    private int currentCard;

    public ImageTrackerManager imgTrkMan;
    public HangulGameManager manager;
    public timerbar tb;
    public ChoiceQuiz cq;
    public ToggleGroup toggleGroup;
    public Toggle[] toggles = new Toggle[4];
    public string motherName;

    public string answer;
    public string [,] answers =
    {
       {"�����", "���"}, {"����", "�ʱ���" }, {"�ٶ���", "����"},{ "���", "����" }, {"����", "����" }, {"����", "��ѱ�" }, {"����", "������" },
       { "����", "����" }, {"�ڵ���", "����ö"},{ "�౸", "ġ��" },{"�ڳ���", "ī�޶�"},{ "�䳢", "�±ر�"},{"����", "���ξ���"},{"ȣ����", "�б�"}
    };

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
            new string[] {"����", "����", "������", "����"}
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
            new string[] {"����ö", "����ö", "������", "������"}
        } },
        {9, new List<string[]>
        {
            new string[] {"�౸", "�˱�", "��ť", "ô��"},
            new string[] {"ġ��", "ġ��", "ġ��", "ü��"}
        } },
        {10, new List<string[]>
        {
            new string[] {"�ڳ���", "�ڱ���", "�����", "Ĭ�ٸ�"},
            new string[] {"ī�޶�", "Ű�޶�", "�ɹ���", "ť�޶�"}
        } },
        {11, new List<string[]>
        {
            new string[] {"�䳢", "Ÿ��", "����", "���"},
            new string[] {"�±ر�", "�±㳢", "Ÿ����", "Ʃ�س�"}
        } },
        {12, new List<string[]>
        {
            new string[] {"����", "Ǫ��", "�۶�", "����"},
            new string[] {"���ξ���", "���ο���", "�������", "�����غ�"}
        } },
        {13, new List<string[]>
        {
            new string[] {"ȣ����", "ȿ����", "ȭ����", "ȸ����"},
            new string[] {"�б�", "�ٱ�", "ȣ��", "Ȯ��"}
        } },
    };

    public void OnButtonClick(int fs, int sc)
    {
        int plusArg = fs + 1;

        if (manager.cardStates[fs] == 0)
        {
            List<string[]> questionList = questions[fs];
            string[] questionChoices = questionList[sc];

            // ������ �迭�� �����ϱ� ���� ���� ����
            answer = answers[fs, sc];
            currentCard = fs;
            string mnc = plusArg.ToString();
            motherName = mnc;

            // ������ �迭�� ����
            string[] shuffledChoices = ShuffleChoices(questionChoices);

            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].GetComponentInChildren<TextMeshProUGUI>().text = shuffledChoices[i];
                toggles[i].group = toggleGroup;
                toggles[i].isOn = false;
            }
        }
    }

    public void CheckAnswer()
    {
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn)
            {
                string selectedAnswer = toggle.GetComponentInChildren<TextMeshProUGUI>().text;
                if (selectedAnswer == answer)
                {
                    cq.KillOfQz();
                    manager.CardCall(currentCard, 1);
                    tb.isRun = false;
                    this.gameObject.SetActive(false);
                }
                else
                {
                    cq.KillOfQz();
                    manager.CardCall(currentCard, 2);
                    tb.isRun = false;
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
