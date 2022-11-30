using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PedometerShow : MonoBehaviour
{
    InputControls controls;

    Text stepCountText;
    // Start is called before the first frame update
    // private void Awake() {
    //     controls = new InputControls();

    //     InputSystem.EnableDevice(StepCounter.current);
    //     stepCountText = this.GetComponent<Text>();
    // }
    // private void OnEnable() {
    //     controls.Enable();
    // }

    // // 비활성화 될 때 실행
    // private void OnDisable() {
    //     controls.Disable();
    //     InputSystem.DisableDevice(StepCounter.current);
    // }

    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (StepCounter.current.enabled){
    //         Debug.Log("StepCounter is enabled");
    //         stepCountText.text = StepCounter.current.ToString();
    //     }
            


    // }
}
