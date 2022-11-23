using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TouchController : MonoBehaviour
{
    [SerializeField]
    float cameraZoomSpeed = 2f;
    float cameraZoomSize = 5f;
    
    public float maxFOV = 180f;
    public float minFOV = 150f;

    InputControls inputControls;
    Coroutine zoomCoroutine;
    // Transform cameraTransform;

    public CinemachineVirtualCamera cinemachineVirtualCamera;
    float virtualCameraFOV;

    private void Awake() {
        inputControls = new InputControls();
        // cameraTransform = Camera.main.transform;
    


        // cinemachineVirtualCamera.m_Lens.FieldOfView = 10f;
    }

    private void OnEnable() {
        inputControls.Enable();        
    }

    private void OnDisable() {
        inputControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputControls.Touch.SecondaryTouchContact.started += _ => ZoomStart();
        inputControls.Touch.SecondaryTouchContact.canceled += _ => ZoomEnd();
    }

    void ZoomStart(){
         zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    void ZoomEnd(){
        StopCoroutine(zoomCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ZoomDetection(){
        float prevDistance = 0f, distance = 0f;

        while(true){
            distance = Vector2.Distance(inputControls.Touch.PrimaryFingerPosition.ReadValue<Vector2>(),
                                        inputControls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());

            // 손가락  사이가 멀어짐
            if(distance > prevDistance){
                float targetPosition = cinemachineVirtualCamera.m_Lens.FieldOfView;

                if(minFOV > targetPosition)
                {
                    targetPosition -= cameraZoomSize;
                }
                else
                {
                    targetPosition = minFOV;
                }
                
                cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, targetPosition, Time.deltaTime * cameraZoomSpeed);
                Debug.Log("손가락 사이가 멀어짐");
            }
            // 손가락 사이가 가까워짐
            else if(distance < prevDistance){
                float targetPosition = cinemachineVirtualCamera.m_Lens.FieldOfView;
                
                if(maxFOV < targetPosition)
                {
                    targetPosition += cameraZoomSize;
                }
                else
                {
                    targetPosition = maxFOV;
                }
                cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(cinemachineVirtualCamera.m_Lens.FieldOfView, targetPosition, Time.deltaTime * cameraZoomSpeed);
                Debug.Log("손가락 사이가 가까워짐");
            }

            prevDistance = distance;
            yield return null;
        }
    }
}
