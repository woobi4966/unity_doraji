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


    Transform ClickedPositionTransform;
    private bool isCollision = false;

    void Start()
    {
        ClickedPositionTransform = ClickedPosition.GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {
        // WALL에 부딪히지 않았으며 도착지의 x값과 같지 않을 때
        if (isCollision == false && transform.position.x != ClickedPositionTransform.position.x)
        {
            // x 좌표가 같지 않을 때만 움직임.
            transform.position = Vector3.Lerp(transform.position, ClickedPositionTransform.position, moveSpeed);
            // rg.MovePosition(transform.position + ClickedPositionTransform.position.normalized * Time.deltaTime * moveSpeed);
        }
    }

    private void OnCollisionEnter(Collision other) {
        // moveCancelwall이라면 이동 멈추기
        // if(other.gameObject.layer == 11){
        //     isCollision = true;
        // }
    }
}
