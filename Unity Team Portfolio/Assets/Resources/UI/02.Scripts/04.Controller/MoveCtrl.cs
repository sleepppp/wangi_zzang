using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCtrl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject tObjcet;
    private RectTransform moveRange;
    private Vector3 defaultPos;

    private float vDir = 0;
    private float hDir = 0;
    private bool moveAble = true;

    // Start is called before the first frame update
    void Start()
    {
        tObjcet = GameObject.Find("TObject");
        moveRange = GetComponentInParent<RectTransform>();
        defaultPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "UI_MoveCtrl")
        {
            Debug.Log("dk");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!moveAble) return;

        transform.position = Input.mousePosition;

        vDir = (transform.position.y - defaultPos.y) / moveRange.rect.height * 0.5f;
        hDir = (transform.position.x - defaultPos.x) / moveRange.rect.width * 0.5f;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = defaultPos;
    }
}
