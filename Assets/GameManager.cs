using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public string DateTime;
    public int feelingSelection;
    public string questionAnswer;

    public Animator anim;


    public Slider Level;
    public Slider friendly;
    JsonRead jsonRead;

    // DateTime과 PlayerPrefs로 유저의 데이터를 저장 관리함.
    void Start()
    {

        // jsonRead = GetComponent<JsonRead>();

        // jsonRead.LoadPlayerDataToJson();
    }

    void UpdateDate()
    {
        jsonRead.UpdateUserDate(questionAnswer, feelingSelection);
    }

    public void SetFeelingSelection(int feelingselect)
    {
        feelingSelection = feelingselect;
    }

    public void SetQuestionAnswer(string answer)
    {
        questionAnswer = answer;
    }


    public void Feeded(float value){
        anim.SetTrigger("jump");
        friendly.value += value;
    }
}