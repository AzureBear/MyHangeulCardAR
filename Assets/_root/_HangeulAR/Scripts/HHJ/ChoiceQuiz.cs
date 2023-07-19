using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceQuiz : MonoBehaviour
{
    public GameObject[] quiz;
    void Start()
    {
        foreach (var item in quiz)
        {
            item.gameObject.SetActive(false);
        }

        quiz[Random.Range(0, quiz.Length)].SetActive(true);
    }


}