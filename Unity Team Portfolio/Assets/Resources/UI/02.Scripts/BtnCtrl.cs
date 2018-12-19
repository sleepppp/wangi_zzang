using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnCtrl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

    private Text text;
    private Image icon;
    private readonly float textOffset = 5.0f;
    private readonly float iconOffset = 3.0f;

    // Use this for initialization
    void Start () {
        text = GetComponentInChildren<Text>();
        icon = transform.GetChild(0).GetComponent<Image>();
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        if (text) text.transform.Translate(0, -textOffset, 0);
        if (icon) icon.transform.Translate(0, -iconOffset, 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (text) text.transform.Translate(0, textOffset, 0);
        if (icon) icon.transform.Translate(0, iconOffset, 0);
    }
}
