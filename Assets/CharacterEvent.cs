using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvent : MonoBehaviour
{
    float timer;
    Animator anim;
    Transform tr;
    float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();

    }

    void Update()
    {

        // 캐릭터의 랜덤 event를 주려고 함.

        // 랜덤 함수로 랜덤의 숫자 선택.
        // int selectedEvent = Random.Range(0, 4);

        // // 숫자에 맞는 애니메이션이 동작.
        // switch(selectedEvent)
        // {
        //     case 1:
        //         // is Walking
        //         break;
        //     case 2:
        //         break;
        //     case 3:
        //         break;
        //     default:
        //         break;
        // }


        // //동작후 몇 초 후에 다시 반복.
        // timer += Time.deltaTime;
        // if(timer > 8f)
        // {
        //     timer = 0;
        // }
    }


        public void FeededAnimation(){
            anim.SetTrigger("jump");
        }
}
