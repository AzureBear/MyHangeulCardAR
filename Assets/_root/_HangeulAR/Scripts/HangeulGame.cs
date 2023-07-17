using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HangeulGame : MonoBehaviour
{
    public int[] cardStates = new int[14];
    public int[] state = { 0, 1, 2 }; // ����ī�� ���� 0,1,2
    public ToggleGroup toggleGroup;
    public Toggle[] toggles = new Toggle[4];

    // consonant �� ��ųʸ� 14�� ���� �� �� 0���� �ʱ�ȭ
    public Dictionary<string, int> cards = new Dictionary<string, int>()
    {
        {"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },
        {"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 },{"��", 0 }
    };

    public string[] answers =
    {
        "�����", "���", "����", "�ʱ���", "�ٶ���", "����", "���", "����", "����", "����", "����", "��ѱ�", "����", "������",
        "����", "����", "�ڵ���", "����ö", "�౸", "ġ��", "�ڳ���", "ī�޶�", "�䳢", "�±ر�", "����", "���ξ���", "ȣ����", "�б�"
    };

    // ����ī�帶�� 4������ 2������ �߰�
    public Dictionary<string, List<string[]>> questions = new Dictionary<string, List<string[]>>
    {
        {"��", new List<string[]>
        {
            new string[] {"�����", "������", "����", "������"},
            new string[] {"���", "����", "���", "����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"����", "�ʺ�", "����", "����"},
            new string[] {"�ʱ���", "����", "�ʰ�", "�ϱ���"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"�ٶ���", "����", "�ٷ���", "�ٶ���"},
            new string[] {"����", "����", "����", "����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"���", "����", "����", "����"},
            new string[] {"����", "����", "������", "�����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"����", "����", "����", "����"},
            new string[] {"����", "�յ�", "�ε�", "����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"����", "����", "����", "����"},
            new string[] {"��ѱ�", "��ѱ�", "�񵹱�", "�����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"����", "����", "����", "�ҹ�"},
            new string[] {"������", "�ջ���", "������", "������"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"����", "����", "���", "����"},
            new string[] {"����", "�߱�", "����", "����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"�ڵ���", "�ڼ���", "������", "������"},
            new string[] {"����ö", "ġ��ö", "������", "ġ����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"�౸", "�˱�", "����", "����"},
            new string[] {"ġ��", "����", "ġ��", "����"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"�ڳ���", "�ڱ���", "������", "���ٸ�"},
            new string[] {"ī�޶�", "Ű�޶�", "�ɹ���", "ť�޶�"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"�䳢", "����", "�γ�", "�볢"},
            new string[] {"�±ر�", "���س�", "�뱹��", "���س�"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"����", "��", "�ε�", "����"},
            new string[] {"���ξ���", "���ο���", "�������", "�����غ�"}
        } },
        {"��", new List<string[]>
        {
            new string[] {"ȣ����", "�����", "ȭ����", "ȸ����"},
            new string[] {"�б�", "�ٱ�", "����", "Ȯ��"}
        } },

    };

    private void Start()
    {
        ShuffleQuestions();
        SetupButtons();
    }

    // 4������ ���� ����
    private void ShuffleQuestions()
    {
        // 4������ ��ųʸ� foreach�� ����� �����ֱ�
        foreach (var questionList in questions.Values)
        {
            ShuffleList(questionList);
        }
    }

    // ... 

    // ��ư ���� �޼���
    private void SetupButtons()
    {
        string randomAnswer = GetRandomAnswer(); // ���� �޼��� ȣ��
        string[] question = GetQuestionWithAnswer(randomAnswer); // ������ ���Ե� ���� ȣ��

        if (question != null) // ������ ������ ������ �迭 ���� �� ��ư �ؽ�Ʈ�� �Ҵ�
        {
            ShuffleArray(question);
            for (int i = 0; i < toggles.Length; i++)
            {
                // Change the text of each toggle to match the question options
                toggles[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = question[i];
                toggles[i].group = toggleGroup; // Assign the ToggleGroup to each toggle
                toggles[i].isOn = false; // Ensure all toggles are initially turned off
            }
        }
    }

    // ������ ���� ��������
    private string GetRandomAnswer()
    {
        int randomIndex = Random.Range(0, answers.Length); // ���� �迭 ���� ���� �ε��� ����
        return answers[randomIndex]; // �ش� �ε����� ��ġ�� ���� ����
    }

    // ������ ���Ե� ���� 4������ ��������
    private string[] GetQuestionWithAnswer(string answer)
    {
        foreach (var questionList in questions.Values)
        {
            foreach (var question in questionList)
            {
                if (question[0] == answer)
                    return question;
            }
        }
        return null;
    }

    // questions ��ųʸ����� ������� ����Ʈ �� �迭 ��
    //����� �迭 ���� �޼��� ( Fisher - Yates ���� �˰���)
    private void ShuffleArray<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    // questions ��ųʸ� ������� ����Ʈ ����
    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            T temp = list[n];
            list[n] = list[k];
            list[k] = temp;

        }
    }
}
