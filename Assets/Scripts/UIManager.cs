using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public TodayQuestion todayQuestion;

    // Menu Part
    public GameObject menuPanel;
    RectTransform menuUIRectTransform;
    RectTransform menuPanelPartTransform;
    float menuPanelPartTransformWidth;
    // menuPanel Variables
    float timer = 0f;
    bool closeMenuFlag = false;
    bool closeCalendarFlag = false;



    // Inventory Part
    public GameObject inventoryPanel;
    RectTransform inventoryTransform;
    public RectTransform arrowIcon; // For btn Rotation
    // inventory Variables
    bool isOpenInventory = false;

    // Calendar Part
    public GameObject CalendarPanel;
    RectTransform CalendarPanelTransform;
    // Calendar Variables
    bool isOpenCalendar = false;


    // FeelingSelection part
    public GameObject feelingSelectionPanel;
    RectTransform feelingSelectionRectTransform;
    // FeelingSelection Variables
    bool isOpenFeelingSelection = false;

    // TOdayQuestion part
    public GameObject toDayQuestionPanel;
    RectTransform toDayQuestionRectTransform;
    // TodayQuestion Variables
    bool isOpenTodayQuestion = false;


    // Start is called before the first frame update
    void Start()
    {
        menuUIRectTransform = menuPanel.GetComponent<RectTransform>();

        inventoryTransform = inventoryPanel.GetComponent<RectTransform>();

        CalendarPanelTransform = CalendarPanel.GetComponent<RectTransform>();

        toDayQuestionRectTransform = toDayQuestionPanel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        AppShutDown();

        // menuPanel이 들어갈때까지 애니메이션이 표현되도록 하기 위해 아래의 조건문이 존재함.
        if (closeMenuFlag) // closeMenu Animation을 위한 시간 계산
        {
            timer += Time.deltaTime; // 계속 시간이 증가
        }
        if (timer > 0.6f)
        {
            menuPanel.SetActive(false);
            closeMenuFlag = false;
            timer = 0f;
        }

        if (closeCalendarFlag) // closeMenu Animation을 위한 시간 계산
        {
            timer += Time.deltaTime; // 계속 시간이 증가
        }
        if (timer > 0.6f)
        {
            CalendarPanel.SetActive(false);
            closeCalendarFlag = false;
            timer = 0f;
        }
    }

    // IEnumerator coru(){
    //     backButtonClickCount = 0;
    // }

    // 모바일에서 뒤로 가기를 두 번 누르면 종료 되도록 만듦.
    void AppShutDown()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // backButtonClickCount++;
            Application.Quit();
        }
    }

    public void OpenMenuBtn()
    {
        // MenuBtn이 클릭되어 이 함수가 실행됨.


        menuPanel.SetActive(true);
        menuPanelPartTransformWidth = menuUIRectTransform.rect.width;
        menuUIRectTransform.DOAnchorPos(new Vector2(0, 0), 0.5f);
        // DoTween을 이용해서 Menu용 Canvas의 Anchor를 왼쪽으로 translate Animation을 적용한다.
    }

    public void CloseMenuBtn()
    {
        // MenuBtn 닫는 버튼이 클릭되어 이 함수가 실행됨.
        // DoTween을 이용해서 Menu용 Canvas의 Anchor를 오른쪽으로 translate Animation을 적용한다.
        closeMenuFlag = true; // 메뉴 닫기 시작
        menuUIRectTransform.DOAnchorPos(new Vector2(menuPanelPartTransformWidth, 0), 0.5f);
    }

    public void Open_CloseInventoryBtn()
    {
        // InventoryBtn이 클릭되어 이 함수가 실행됨.
        if (isOpenInventory != true)
        {
            inventoryTransform.DOAnchorPos(new Vector2(0, 435), 0.5f);
            isOpenInventory = true;
            arrowIcon.SetPositionAndRotation(arrowIcon.position, new Quaternion(180, 0, 0, 0));
        }
        else
        {
            inventoryTransform.DOAnchorPos(new Vector2(0, 0), 0.3f);
            isOpenInventory = false;
            arrowIcon.SetPositionAndRotation(arrowIcon.position, new Quaternion(0, 0, 0, 0));
        }

    }

    public void Open_closeCanlendar()
    {

        if (isOpenCalendar != true)
        {
            CalendarPanel.SetActive(true);
            isOpenCalendar = true;
            CalendarPanelTransform.DOAnchorPos(new Vector2(0, 0), 0.5f);
        }
        else
        {
            closeCalendarFlag = true;
            isOpenCalendar = false;
            CalendarPanelTransform.DOAnchorPos(new Vector2(0, 1400), 0.5f);
        }
    }



    public void Open_closeFeelingSelection()
    {
        if (isOpenFeelingSelection != true)
        {
            feelingSelectionPanel.SetActive(true);
            isOpenFeelingSelection = true;
        }
        else
        {
            feelingSelectionPanel.SetActive(false);
            isOpenFeelingSelection = false;
        }
    }

    public void Open_closeTodayQuestion()
    {
        if (isOpenTodayQuestion != true)
        {
            todayQuestion.SetQuestionToGameManager();
            toDayQuestionPanel.SetActive(true);
            isOpenTodayQuestion = true;
        }
        else
        {
            toDayQuestionPanel.SetActive(false);
            isOpenTodayQuestion = false;
        }

    }

}
