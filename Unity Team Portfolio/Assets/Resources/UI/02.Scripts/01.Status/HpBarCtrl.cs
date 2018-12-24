using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarCtrl : MonoBehaviour
{
    private TestObject tObject;
    private Image hpImage;
    private Text hpText;
    private Sprite[] stateImage = new Sprite[3];

    private int preHp;

    // Start is called before the first frame update
    void Start()
    {
        tObject = GameObject.Find("TObject").GetComponent<TestObject>();
        hpImage = GetComponent<Image>();
        hpText = GetComponentInChildren<Text>();
        stateImage[0] = Resources.Load<Sprite>("UI/01.Images/UI_Fill_Green");
        stateImage[1] = Resources.Load<Sprite>("UI/01.Images/UI_Fill_Orange");
        stateImage[2] = Resources.Load<Sprite>("UI/01.Images/UI_Fill_Red");
        preHp = tObject.Hp;
        StartCoroutine(ChangeHpBar());
    }

    IEnumerator ChangeHpBar()
    {
        while (true)
        {
            WaitUntil waitUntil = new WaitUntil(() => preHp != tObject.Hp);

            hpText.text = string.Format(tObject.Hp + " / " + tObject.MaxHp);
            hpImage.fillAmount = (float)tObject.Hp / (float)tObject.MaxHp;
            preHp = tObject.Hp;

            if (hpImage.fillAmount >= 0.66f) hpImage.sprite = stateImage[0];
            else if (hpImage.fillAmount < 0.66f && hpImage.fillAmount >= 0.33f) hpImage.sprite = stateImage[1];
            else hpImage.sprite = stateImage[2];

            yield return waitUntil;
        }
    }
}
