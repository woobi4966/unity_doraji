using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Calendar : MonoBehaviour
{
    GameObject canvas;
    public GameObject prefab;
    public static DateTime SelectDate;
    private DateTime D_Date;
    private int startday;
    // public Text mytext;
    private void CalendarController()
    {
        int days = 1;
        int overday = 1;

        D_Date = new DateTime(SelectDate.Year, SelectDate.Month, 1);  // SelectDate의 최초의 날
        int year = SelectDate.Year; //년
        int month = SelectDate.Month; //월
        int day = SelectDate.Day; //일
        Debug.Log(year + month + day);
        //최초의 날의 요일을 취득
        DayOfWeek firstDate = D_Date.DayOfWeek;
        //몇일까지있는지
        int monthEnd = DateTime.DaysInMonth(year, month);
        //지난월이 몇일까지
        SelectDate = SelectDate.AddMonths(-1);
        month = SelectDate.Month;
        SelectDate = SelectDate.AddMonths(1);
        int lastmonth = DateTime.DaysInMonth(year, month);
        switch (firstDate)
        {
            case DayOfWeek.Sunday:
                startday = 0;
                break;
            case DayOfWeek.Monday:
                startday = 1;
                break;
            case DayOfWeek.Tuesday:
                startday = 2;
                break;
            case DayOfWeek.Wednesday:
                startday = 3;
                break;
            case DayOfWeek.Thursday:
                startday = 4;
                break;
            case DayOfWeek.Friday:
                startday = 5;
                break;
            case DayOfWeek.Saturday:
                startday = 6;
                break;
        }
        int lastmonthdays = lastmonth - startday + 1;

        for (int i = 0; i < 42; i++)
        {
            if (i >= startday)
            {
                if (days <= monthEnd)
                {
                    // 글 입력
                    Transform DAY = GameObject.Find("GameObject").transform.GetChild(i);
                    DateTime tmp = D_Date;//일시변수
                    DayOfWeek num = tmp.DayOfWeek;
                    // 토요일 파랑색 ,일요일 빨간색
                    switch (num)
                    {
                        case DayOfWeek.Sunday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.red;
                            break;
                        case DayOfWeek.Saturday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.blue;
                            break;
                        default:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.black;
                            break;

                    }
                    DAY.GetChild(0).GetComponent<Text>().text = D_Date.Day.ToString();
                   
                    GameObject button = GameObject.Find("GameObject").transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    button.GetComponent<Button>().onClick.AddListener(() => { set_Date(tmp); });
                    D_Date = D_Date.AddDays(1);
                    days++;
                }
                else
                {
                    Transform DAY = GameObject.Find("GameObject").transform.GetChild(i);
                    DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                    DAY.GetChild(0).GetComponent<Text>().text = overday.ToString();
                    GameObject button = GameObject.Find("GameObject").transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    overday++;
                }
            }
            else
            {
                Transform DAY = GameObject.Find("GameObject").transform.GetChild(i);
                DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                DAY.GetChild(0).GetComponent<Text>().text = lastmonthdays.ToString();
                GameObject button = GameObject.Find("GameObject").transform.GetChild(i).gameObject;
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                lastmonthdays++;
            }
        }

        void set_Date(DateTime date)
        {
            Debug.Log(date);
            // 날 표시 
        }
    
    }

    void Start()
    {
        canvas = this.gameObject;
        for (int i = 0; i < 42; i++)
        {
            GameObject button = Instantiate(prefab, canvas.transform);
            button.GetComponent<Button>();
        }
            SelectDate = DateTime.Now;
            
            CalendarController();
    }
    


}