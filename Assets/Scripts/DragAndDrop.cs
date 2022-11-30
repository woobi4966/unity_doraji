using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler//, IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    private float dampingSpeed = 0.05f;
    private RectTransform draggingObjectRectTransform;
    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        draggingObjectRectTransform = transform as RectTransform;
    }
    public void OnDrag(PointerEventData eventData)
    {
        // rect transform을 이동시켜서 drag and drop 처럼 보이게 함.
        if(RectTransformUtility.ScreenPointToWorldPointInRectangle(draggingObjectRectTransform, eventData.position, eventData.pressEventCamera, out var globalMousePosition)){
            draggingObjectRectTransform.position = Vector3.SmoothDamp(draggingObjectRectTransform.position, globalMousePosition, ref velocity, dampingSpeed);
            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }

    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
            // collider로 확인해봐. layer가 character가 아니면 원래 자리로 돌아가기
    // }


}
