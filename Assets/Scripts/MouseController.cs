using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{

    public Vector3 mouseWorldPosition;
    public Vector3 mouseScreenPosition;
    public Transform mousePositionObject;
    public float yPosition = 60f; // mousePosition Object의 y값 위치
    public Transform character;
    // yposition의 값을 캐릭터의 위치에서 -10f 정도로 지정하면?
    public LayerMask layersToHit;

    private InputControls controls;
    private Camera cameraMain;
    
    public static MouseController MouseControllerInstance;

    // 최초 한 번만 실행됨.
    private void Awake() {
        controls = new InputControls();
        MouseControllerInstance = this;
    }

    // 활성화 될 때 실행
    private void OnEnable() {
        controls.Enable();
    }

    // 비활성화 될 때 실행
    private void OnDisable() {
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


    void Update()
    {
        // 실시간으로 마우스 포인트의 위치를 확인
        mouseScreenPosition = controls.Mouse.Position.ReadValue<Vector2>(); // mouse의 SCREEN 상의 위치
        // mouseScreenPosition.z = cameraMain.nearClipPlane + 1; // 카메라 화면의 가장 가까운 정면과의 거리에 +1을 함으로써 카메라 화면보다 조금 뒤에 위치하게 함. -> 카메라에 오브젝트가 보일 수 있는 위치가 됨.
        // mouseScreenPosition.z = 0;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition); // mouse의 WOrld 상의 위치로 변환
        mouseWorldPosition.z = 0;
    }

    // 클릭 시작했을 때
    private void StartedClick() {

    }

    // 클릭이 끝났을 때
    private void EndedClick() {
        ClickPointPositionToObject(); // 마우스의 위치
    }


    // FUNCTION : 마우스가 클릭한 물체 정보 return
    private void DetectObject(){
        Ray ray = cameraMain.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider != null) {
                Debug.Log("3D Hit : " + hit.collider.tag);
            }
        }
    }


    // FUNCTION : 마우스가 클릭한 위치 return
    private void ClickPointPositionToObject() {
        

        // #0
        // raycast를 이용해서 charcter 뒤에 있는 plane의 collider를 통해 마우스월드좌표를 얻는다
        Ray ray = cameraMain.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, layersToHit)){
                mouseWorldPosition = hit.point;
            }


        // #1
        // mousePositionObject의 위치가 지금 클릭된 위치로 이동됨.
        // 이후 Character는 mousePositionObject의 위치로 이동함.
        yPosition = character.position.y - 10f;
        mousePositionObject.position = new Vector3(mouseWorldPosition.x, yPosition, mouseWorldPosition.z);
    }

    public Vector3 GetMouseWorldPosition()
    {
        return mouseWorldPosition;
    }

    public Vector3 GetMouseScreenPosition()
    {
        return mouseScreenPosition;
    }
}