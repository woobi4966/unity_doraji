using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Date : MonoBehaviour
{
    public Text text;

    public DateTime todayDate = System.DateTime.UtcNow.Date;
    public DateTime CharacterBirthDayDate = new DateTime(2022, 11, 29);
    // d-day구하기
    void Start()
    {
        print(todayDate);
        print(todayDate.ToString("yyyy/MM/dd"));
        print("태어난지 : " + DateTime.Compare(todayDate, CharacterBirthDayDate));

    }

    void Update()
    {
        // string time = System.DateTime.UtcNow.ToLocalTime().ToString("yyyy/MM/dd     HH:mm:ss");
        // print(time);
        // text.text = time;
    }
}
