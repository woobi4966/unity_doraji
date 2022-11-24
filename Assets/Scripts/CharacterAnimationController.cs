using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationController : MonoBehaviour
{
    Animator anim;
    Transform tr;
    CharactermoveByClick characterMoveByClick;

    void Start()
    {
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        characterMoveByClick = GetComponent<CharactermoveByClick>();
    }

    
    void Update()
    {
        // Character.transform가 mousePosition와 같을 때
        // Debug.Log("GetIsWalking : " + characterMoveByClick.GetIsWalking());
        if(characterMoveByClick.GetIsWalking() == false)
        {
            anim.SetBool("isWalking", false);
            // Debug.Log("Animator : Standing");
        }
        else{
            anim.SetBool("isWalking", true);
            // Debug.Log("Animator : Walking");
        }
    }
}
