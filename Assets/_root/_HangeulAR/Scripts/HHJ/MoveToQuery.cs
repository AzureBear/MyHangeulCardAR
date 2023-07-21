using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class MoveToQuery : MonoBehaviour
{
    private bool isOver = false;
    
    private void OnMouseDown()
    {
        if (!isOver)
        {
            int first = ((int.Parse(this.name.Split("-")[0])) - 1);
            int second = ((int.Parse(this.name.Split("-")[1])) - 1);
            HangulGameManager.sc.SetActive(false);
            HangulGameManager.instance.MeuSelect("query");
            HangulGameManager.queryGame.OnButtonClick(first, second);
            HangulGameManager.queryGame.cq = this.GetComponentInParent<ChoiceQuiz>();
            HangulGameManager.tb.ReceiveQz(first);
            isOver = true;
        }
    }
}
