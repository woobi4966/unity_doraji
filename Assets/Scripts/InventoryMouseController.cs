using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMouseController : MonoBehaviour
{

    
    
    Camera cameraMain;
    private InputControls controls;
    public LayerMask layersToHit;
    public static InventoryMouseController inventoryMouseControllerInstance;
    private void Awake() {
        controls = new InputControls();
        inventoryMouseControllerInstance = this;
    }

    // 활성화 될 때 실행
    private void OnEnable() {
        controls.Enable();
    }

    // 비활성화 될 때 실행
    private void OnDisable() {
        controls.Disable();
    }

    void Start()
    {   
        cameraMain = Camera.main;
        controls.Mouse.Click.started += _ => StartedClick(); // __ => __ 이런 형식은 lambda function임.
        controls.Mouse.Click.performed += _ => EndedClick();
        Debug.Log("MouseController Mounted.");
    }


    void Update()
    {
        // mouse가 draggable 아이템을 가지고 있는 것을 확인
        // mouse가 Character 위에 있는 것을 확인

        // Drop 시
        // 캐릭터의 호감도 상승   
    }


    private void StartedClick() {

    }

    // 클릭이 끝났을 때
    private void EndedClick() {
        DetectObject();
        Debug.Log("clicked");
        
    }

    private void DetectObject(){
        Ray ray = cameraMain.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider != null) {
                Debug.Log("3D Hit : " + hit.collider.name);
            }
        }
    }

    private void ClickPointPositionToObject() {
        Ray ray = cameraMain.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100, layersToHit)){
                Debug.Log("hit Object : " + hit.collider);
        }


        // #1
        // mousePositionObject의 위치가 지금 클릭된 위치로 이동됨.
        // 이후 Character는 mousePositionObject의 위치로 이동함.
        // yPosition = character.position.y - 10f;
        // mousePositionObject.position = new Vector3(mouseWorldPosition.x, yPosition, mouseWorldPosition.z);
    }
}
