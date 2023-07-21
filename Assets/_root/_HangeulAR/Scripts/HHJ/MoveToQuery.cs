using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class MoveToQuery : MonoBehaviour
{
    public bool isOver;
    private ChoiceQuiz pan;

    private void Start()
    {
        isOver = false;
        pan = this.GetComponentInParent<ChoiceQuiz>();
        pan.pan.SetActive(true);
    }

    private void OnEnable()
    {
        isOver = false;
        pan.pan.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (!isOver)
        {
            int first = ((int.Parse(this.name.Split("-")[0])) - 1);
            int second = ((int.Parse(this.name.Split("-")[1])) - 1);
            HangulGameManager.instance.MeuSelect("query");
            HangulGameManager.queryGame.OnButtonClick(first, second);
            HangulGameManager.QueryContainer[first] = this;
            HangulGameManager.queryGame.cq = this.GetComponentInParent<ChoiceQuiz>();
            HangulGameManager.tb.ReceiveQz(first);
            isOver = true;
        }
    }
}
