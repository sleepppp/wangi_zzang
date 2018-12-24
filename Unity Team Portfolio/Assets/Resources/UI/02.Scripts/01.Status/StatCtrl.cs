using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StatCtrl : MonoBehaviour
{
    enum StatText
    {
        TEXT_NAME,
        TEXT_LEVEL,
        TEXT_EXP,
        TEXT_HP,
        TEXT_SP,
        TEXT_VITAL,
        TEXT_STRENGTH,
        TEXT_STAMIN,
        TEXT_DEXTERITY,
        TEXT_STATPOINT
    }

    enum StatPlus
    {
        PLUS_VITAL,
        PLUS_STRENGTH,
        PLUS_STAMIN,
        PLUS_DEXTERITY
    }

    private TestObject tObject;

    private List<Image> barImage = new List<Image>();
    private List<Text> lStat = new List<Text>();
    private List<Button> lPlusButton = new List<Button>();

    private void Start()
    {
        tObject = GameObject.Find("TObject").GetComponent<TestObject>();

        GameObject[] uiBar = GameObject.FindGameObjectsWithTag("UI_Bar");
        for (int i=0; i<uiBar.Length; i++)
        {
            barImage.Add(uiBar[i].GetComponentInChildren<Image>());
        }

        lStat = GetComponentsInChildren<Text>().ToList();
        lPlusButton = GetComponentsInChildren<Button>().ToList();

        StatusUIInit();
    }

    private void StatusUIInit()
    {
        for (int i = 0; i < lStat.Count; i++)
        {
            switch (i)
            {
                case (int)StatText.TEXT_NAME:
                    lStat[i].text = string.Format(tObject.ObjcetName);
                    break;
                case (int)StatText.TEXT_LEVEL:
                    lStat[i].text = string.Format(tObject.Level.ToString());
                    break;
                case (int)StatText.TEXT_EXP:
                    lStat[i].text = string.Format(tObject.Exp.ToString() + "/" + tObject.MaxExp.ToString());
                    break;
                case (int)StatText.TEXT_HP:
                    lStat[i].text = string.Format(tObject.Hp.ToString() + "/" + tObject.MaxHp.ToString());
                    break;
                case (int)StatText.TEXT_SP:
                    lStat[i].text = string.Format(tObject.Sp.ToString() + "/" + tObject.MaxSp.ToString());
                    break;
                case (int)StatText.TEXT_VITAL:
                    lStat[i].text = string.Format(tObject.Vit.ToString());
                    break;
                case (int)StatText.TEXT_STRENGTH:
                    lStat[i].text = string.Format(tObject.Str.ToString());
                    break;
                case (int)StatText.TEXT_STAMIN:
                    lStat[i].text = string.Format(tObject.Stm.ToString());
                    break;
                case (int)StatText.TEXT_DEXTERITY:
                    lStat[i].text = string.Format(tObject.Dex.ToString());
                    break;
                case (int)StatText.TEXT_STATPOINT:
                    lStat[i].text = string.Format(tObject.StatPoint.ToString());
                    break;
            }
        }
    }
}
