using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIScaler : MonoBehaviour
{
    // 상위 canvas의 height를 가져와서 이 갑을 본인의 height값으로 정의함.
    
    public RectTransform parentCanvasTransform;
    private RectTransform thisRectTransform;

    void Start()
    {
        thisRectTransform = GetComponent<RectTransform>();

        Debug.Log(parentCanvasTransform.rect.width + " / " + parentCanvasTransform.rect.height);
        float toBeWidth = parentCanvasTransform.rect.width;
        float toBeheight = parentCanvasTransform.rect.height;

        thisRectTransform.sizeDelta = new Vector2(toBeWidth, toBeheight);

        float left = thisRectTransform.offsetMin.x;
        float bottom = thisRectTransform.offsetMin.y;


        float right = thisRectTransform.offsetMax.x;
        float top = thisRectTransform.offsetMax.y;

        thisRectTransform.offsetMin = new Vector2(Screen.width - toBeWidth, Screen.height - toBeheight);
        thisRectTransform.offsetMax = new Vector2(toBeWidth - Screen.width, toBeheight - Screen.height);

        Debug.Log("after : " + thisRectTransform.rect.width + " / " + thisRectTransform.rect.height);
    }


    private void OnEnable() {
        
    }
}
