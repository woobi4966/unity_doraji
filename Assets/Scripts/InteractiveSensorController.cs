using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSensorController : MonoBehaviour
{
    /*
    이 스크립트에서 캐릭터의 몸을 터치했을 때 호감도와 체력에 따른 애니메이션이 작동되고
    이러한 작용에 대한 결과를 캐릭터 상태 시스템에 적용시키는 기능을 구현함.
    */


    //////// cursorController에서 참조함.
    private Vector3 mouseWorldPosition;
    private Vector3 mouseScreenPosition;

    public static MouseController cursorControllerInstance;

    public LayerMask layersToHit; // Position을 얻기 위한 layer 지정

    private InputControls controls;
    private Camera cameraMain;


    // 최초 한 번만 실행됨.
    private void Awake()
    {
        controls = new InputControls();
    }

    // 활성화 될 때 실행
    private void OnEnable()
    {
        controls.Enable();
    }

    // 비활성화 될 때 실행
    private void OnDisable()
    {
        controls.Disable();
    }


    // 최초 한 번만 실행됨. awake()가 실행된 후 실행됨.
    void Start()
    {
        cameraMain = Camera.main;

        // 아래 두 줄은 각각 클릭 됐을 때, 클릭이 된 후에를 lambda 함수 형식으로 함수를 실행하라는 의미.
        controls.Mouse.Click.started += _ => StartedClick(); // __ => __ 이런 형식은 lambda function임.
        controls.Mouse.Click.performed += _ => EndedClick();
    }


    void FixedUpdate()
    {
        // cursorController를 통해 MouseWorldPosition을 가져옴.
        // mouseWorldPosition = cursorControllerInstance.GetMouseWorldPosition();
    }

    // 클릭 시작했을 때
    private void StartedClick()
    {

    }

    // 클릭이 끝났을 때
    private void EndedClick()
    {
        // 각 sensor별 IF-ELSE 문 작동
        DetectObject();
    }


    // FUNCTION : 마우스가 클릭한 물체 정보 return
    private void DetectObject()
    {
        Ray ray = cameraMain.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider.isTrigger == true)
            {
                Debug.Log("interativeSensorWorked : " + hit.collider.name);
            }
        }
    }


}
