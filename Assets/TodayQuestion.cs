using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TodayQuestion : MonoBehaviour
{
    public GameManager gameManager;
    public InputField text;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetQuestionToGameManager(){
        gameManager.SetQuestionAnswer(text.text);
        Debug.Log("updated");
    }


    
}
