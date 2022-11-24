using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactermoveByClick : MonoBehaviour
{
    /*
    이 스크립트에서 캐릭터가 CursorController를 통해 구해진
    MousePositionObject의 Position으로 움직이게 구현함.
    */
    public GameObject ClickedPosition;
    public float moveSpeed;

    bool isWalking; // 걷고 있는지 확인

    Transform ClickedPositionTransform;
    private bool isCollision = false;

    void Start()
    {
        ClickedPositionTransform = ClickedPosition.GetComponent<Transform>();
        isWalking = false;
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        // WALL에 부딪히지 않았으며 도착지의 x값과 같지 않을 때
        // 움직이는 중
        if (isCollision == false && transform.position.x != ClickedPositionTransform.position.x)
        {
            // x 좌표가 같지 않을 때 = 걷기
            if(transform.position.x > ClickedPositionTransform.position.x+2 || transform.position.x < ClickedPositionTransform.position.x-2)
            {
                // 걷기
                Vector3 dir = ClickedPositionTransform.position - transform.position;
                // transform.position = Vector3.Lerp(transform.position, ClickedPositionTransform.position, moveSpeed);
                transform.position = transform.position + dir *  moveSpeed * Time.deltaTime;
                
                
                if (isWalking == false) // 서 있는 거 멈추고 걷기 시작
                {
                    isWalking = true;
                    Debug.Log("ChractermoveByClick : 움직이기 시작," + isWalking);
                }
            }
            else // 멈추기
            {
                // x 좌표가 같아서 정지한다.
                if(isWalking != false){
                    isWalking = false;
                    Debug.Log("ChractermoveByClick : 정지," + isWalking);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        // moveCancelwall이라면 이동 멈추기
        if(other.gameObject.layer == 11){
            isCollision = true;
            if(isWalking == true)
            {
                isWalking = false;
            }
            ClickedPosition.transform.position = transform.position;
        }
    }

    public bool GetIsWalking(){
        return isWalking;
    }
}
