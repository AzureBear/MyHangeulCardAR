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
        {"ㄱ", 0 },{"ㄴ", 0 },{"ㄷ", 0 },{"ㄹ", 0 },{"ㅁ", 0 },{"ㅂ", 0 },{"ㅅ", 0 },
        {"ㅇ", 0 },{"ㅈ", 0 },{"ㅊ", 0 },{"ㅋ", 0 },{"ㅌ", 0 },{"ㅍ", 0 },{"ㅎ", 0 }
    };
    */

    public string answer;
    public string [,] answers =
    {
       {"고양이", "고기"}, {"나비", "너구리" }, {"다람쥐", "돼지"},{ "라면", "라디오" }, {"모자", "만두" }, {"바지", "비둘기" }, {"수박", "선생님" },
       { "우유", "여우" }, {"자동차", "지하철"},{ "축구", "치즈" },{"코끼리", "카메라"},{ "토끼", "태극기"},{"포도", "파인애플"},{"호랑이", "학교"}
    };


    // 자음카드마다 4지선다 2개문제 추가
    public Dictionary<int, List<string[]>> questions = new Dictionary<int, List<string[]>>
    {
        {0, new List<string[]>()
        {
            new string[] {"고양이", "구양이", "고영이", "괴양이"},
            new string[] {"고기", "과기", "고거", "구기"}
        } },
        {1, new List<string[]>
        {
            new string[] {"나비", "너비", "내비", "나베"},
            new string[] {"너구리", "나고리", "너고리", "니구리"}
        } },
        {2, new List<string[]>
        {
            new string[] {"다람쥐", "디렘지", "다럼지", "다람지"},
            new string[] {"돼지", "되지", "돼제", "되제"}
        } },
        {3, new List<string[]>
        {
            new string[] {"라면", "러면", "레먼", "리만"},
            new string[] {"라디오", "라기오", "리지오", "나디오"}
        } },
        {4, new List<string[]>
        {
            new string[] {"모자", "무지", "마주", "미자"},
            new string[] {"만두", "먼두", "민도", "맨투"}
        } },
        {5, new List<string[]>
        {
            new string[] {"바지", "바제", "버즈", "비지"},
            new string[] {"비둘기", "배둘기", "비돌기", "버들기"}
        } },
        {6, new List<string[]>
        {
            new string[] {"수박", "서박", "수백", "소박"},
            new string[] {"선생님", "손샌님", "성샌님", "생선님"}
        } },
        {7, new List<string[]>
        {
            new string[] {"우유", "오유", "어요", "오이"},
            new string[] {"여우", "야구", "아이", "여아"}
        } },
        {8, new List<string[]>
        {
            new string[] {"자동차", "자손차", "지동차", "저금차"},
            new string[] {"지하철", "치아철", "지이잘", "치허잘"}
        } },
        {9, new List<string[]>
        {
            new string[] {"축구", "촉구", "족구", "착쿠"},
            new string[] {"치즈", "지츠", "치츠", "시즈"}
        } },
        {10, new List<string[]>
        {
            new string[] {"코끼리", "코길이", "국걸이", "각꾸리"},
            new string[] {"카메라", "키메라", "케무라", "큐메라"}
        } },
        {11, new List<string[]>
        {
            new string[] {"토끼", "도끼", "두끼", "노끼"},
            new string[] {"태극기", "내극끼", "대국기", "래극끼"}
        } },
        {12, new List<string[]>
        {
            new string[] {"포도", "모도", "부도", "포토"},
            new string[] {"파인애플", "바인에플", "파인헤븐", "바인해불"}
        } },
        {13, new List<string[]>
        {
            new string[] {"호랑이", "요랑이", "화랑이", "회롱이"},
            new string[] {"학교", "핵교", "도쿄", "확교"}
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

            // 선택지 배열을 셔플하기 전에 정답 설정
            answer = answers[fs, sc];
            currentCard = fs;

            // 선택지 배열을 셔플
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
