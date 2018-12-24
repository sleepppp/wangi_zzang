using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Transform inven;
    private Transform prevTr;
    public static GameObject draggingItem = null;

    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.Find("InventoryPaper").GetComponent<Transform>();
        canvasGroup = GetComponent<CanvasGroup>();
    
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        prevTr = transform.parent;
        transform.SetParent(inven);

        draggingItem = this.gameObject;

        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingItem = null;
        canvasGroup.blocksRaycasts = true;

        if(transform.parent == inven)
        {
            transform.SetParent(prevTr);
        }
    }

}
