using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveCtrl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private GameObject tObjcet;
    private RectTransform moveRange;
    private RectTransform joyStick;
    private Vector2 inputVector;
    public Vector2 InputVector { get { return inputVector; } }


    // Start is called before the first frame update
    void Start()
    {
        tObjcet = GameObject.Find("TObject");
        moveRange = transform.parent.GetComponent<RectTransform>();
        joyStick = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        #region 기본 방식
        /*
         *  if(RectTransformUtillity.ScreenPointToLocalPointInRectangle(moveRange, eventData.position, eventData.pressEventCamera, out pos))
         *  {
         *      pos.x = (pos.x / moveRange.sizeDelta.x);
         *      pos.y = (pos.y / moveRange.sizeDelta.y);
         * 
         *      inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
         *      inputVector = (inputVetor.magnitude > 1.0f) ? inputVector.normalized : inputVector;
         *      joyStick.anchoredPosition = new Vector3(inputVector.x * moveRange.sizeDelta.x * 0.33,
         *                                              inputVector.y * moveRange.szieDelta.y * 0.33);
         *  }
         */
        #endregion

        pos.x = (Input.mousePosition.x - moveRange.position.x) / (moveRange.sizeDelta.x * 0.25f);
        pos.y = (Input.mousePosition.y - moveRange.position.y) / (moveRange.sizeDelta.y * 0.25f);

        inputVector = pos;

        inputVector = inputVector.magnitude >= 1.0f ? inputVector.normalized : inputVector;

        joyStick.anchoredPosition = new Vector2(inputVector.x * moveRange.sizeDelta.x * 0.5f,
                                         inputVector.y * moveRange.sizeDelta.y * 0.5f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        joyStick.anchoredPosition = Vector2.zero;
        inputVector = Vector2.zero;
    }

}
