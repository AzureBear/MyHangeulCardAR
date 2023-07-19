using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class MoveToQuery : MonoBehaviour
{
    
    public HangeulGame hangeulGame;
    
    public string answer;
    void Start()
    {
      

        hangeulGame = GameObject.FindFirstObjectByType<HangeulGame>();
        int first =  (int.Parse(this.name.Split("-")[0]) - 1) ;
        int second = (int.Parse(this.name.Split("-")[1]) - 1) ;


        answer = hangeulGame.answers[first, second];
    }
    
    // Update is called once per frame
    private void OnMouseDown()
    {
        
        HangulGameManager.instance.MeuSelect("query");
       

      
    }
}
