using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceQuiz : MonoBehaviour
{
    public GameObject[] quiz;
    public GameObject pan;
    public GameObject mother;

    void Start()
    {
        foreach (var item in quiz)
        {
            item.gameObject.SetActive(false);
        }

        quiz[Random.Range(0, quiz.Length)].SetActive(true);

    }

    public void EndOfQuiz(string identifier)
    {
        string mnIdent = mother.name;

        if (mnIdent == identifier)
        {
            pan.SetActive(false);
            foreach (var item in quiz)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    public void KillOfQz()
    {
        pan.SetActive(false);
        foreach (var item in quiz)
        {
            item.gameObject.SetActive(false);
        }
    }

}