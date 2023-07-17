using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangleGame : MonoBehaviour
{
    public GameObject[] buttons; // 버튼 4개

    public int[] state = { 0, 1, 2 }; // 자음카드 상태 0,1,2

    // consonant 값 딕셔너리 14개 저장 각 값 0으로 초기화
    public Dictionary<string, int> cards = new Dictionary<string, int>()
    {
        {"ㄱ", 0 },{"ㄴ", 0 },{"ㄷ", 0 },{"ㄹ", 0 },{"ㅁ", 0 },{"ㅂ", 0 },{"ㅅ", 0 },
        {"ㅇ", 0 },{"ㅈ", 0 },{"ㅊ", 0 },{"ㅋ", 0 },{"ㅌ", 0 },{"ㅍ", 0 },{"ㅎ", 0 }
    };

    public string[] answers =
    {
        "고양이", "고기", "나비", "너구리", "다람쥐", "돼지",

    };

    // 자음카드마다 4지선다 2개문제 추가
    public Dictionary<string, List<string[]>> questions = new Dictionary<string, List<string[]>>
    {
        {"ㄱ", new List<string[]>
        {
            new string[] {"고양이", "구양이", "고영이", "괴양이"},
            new string[] {"고기", "과기", "고거", "구기"}
        } },
        {"ㄴ", new List<string[]>
        {
            new string[] {"나비", "너비", "내비", "나베"},
            new string[] {"너구리", "나고리", "너고리", "니구리"}
        } },
        {"ㄷ", new List<string[]>
        {
            new string[] {"다람쥐", "디렘지", "다럼지", "다람지"},
            new string[] {"돼지", "되지", "돼제", "되제"}
        } },

    };

    private void Start()
    {
        ShuffleQuestions();
        SetupButtons();
    }

    // 4지선다 랜덤 섞기
    private void ShuffleQuestions()
    {
        // 4지선다 딕셔너리 foreach로 밸류값 섞어주기
        foreach (var questionList in questions.Values)
        {
            ShuffleList(questionList);
        }
    }

    // 버튼 설정 메서드
    private void SetupButtons()
    {
        string randomAnswer = GetRandomAnswer(); // 랜덤 메서드 호출
        string[] question = GetQuestionWithAnswer(randomAnswer); // 정답이 포함된 문제 호출

        if (question != null) // 문제가 있을시 선택지 배열 섞은 후 버튼 텍스트에 할당
        {
            ShuffleArray(question);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponentInChildren<Text>().text = question[i + 1];
            }
        }
    }

    // 랜덤한 정답 가져오기
    private string GetRandomAnswer()
    {
        int randomIndex = Random.Range(0, answers.Length); // 정답 배열 길이 랜덤 인덱스 생성
        return answers[randomIndex]; // 해당 인덱스에 위치한 정답 리턴
    }

    // 정답이 포함된 문제 4지선다 가져오기
    private string[] GetQuestionWithAnswer(string answer)
    {   
        foreach (var questionList in questions.Values)
        {
            foreach (var question in questionList)
            {
                if (question[0] == answer)
                    return question;
            }
        } return null;
    }

    // questions 딕셔너리에서 밸류값인 리스트 안 배열 중
    //사용할 배열 섞는 메서드 ( Fisher - Yates 셔플 알고리즘)
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

    // questions 딕셔너리 밸류값인 리스트 섞기
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
