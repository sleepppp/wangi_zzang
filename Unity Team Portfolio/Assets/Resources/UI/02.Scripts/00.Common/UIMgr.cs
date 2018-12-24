using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIMgr : MonoBehaviour
{
    enum LUIMenu
    {
        MAIN,
        ADDON,
        STATUS,
        INVENTORY,
        QUEST
    }

    private List<GameObject> vLMenu;
    private readonly Vector2Int setScreenRatio = new Vector2Int(16, 9);
    private void Awake()
    {
        Screen.SetResolution(Screen.width, Screen.width * setScreenRatio.x / setScreenRatio.y, true);
        vLMenu = GameObject.FindGameObjectsWithTag("LUI_Panel").ToList();

        for (int i = 0; i < vLMenu.Count; i++)
        {
            vLMenu[i].SetActive(i == (int)LUIMenu.MAIN ? true : false);
        }

    }

    public void OpenCloseAddOnMenu()
    {
        if (!((int)LUIMenu.MAIN < vLMenu.Count || (int)LUIMenu.ADDON < vLMenu.Count)) return;

        vLMenu[(int)LUIMenu.MAIN].SetActive(!vLMenu[(int)LUIMenu.MAIN].activeSelf);
        vLMenu[(int)LUIMenu.ADDON].SetActive(!vLMenu[(int)LUIMenu.ADDON].activeSelf);
    }

    public void OpenCloseStatus()
    {
        if (!((int)LUIMenu.ADDON < vLMenu.Count || (int)LUIMenu.STATUS < vLMenu.Count)) return;

        vLMenu[(int)LUIMenu.ADDON].SetActive(!vLMenu[(int)LUIMenu.ADDON].activeSelf);
        vLMenu[(int)LUIMenu.STATUS].SetActive(!vLMenu[(int)LUIMenu.STATUS].activeSelf);
    }

    public void OpenCloseInventory()
    {
        if (!((int)LUIMenu.ADDON < vLMenu.Count || (int)LUIMenu.INVENTORY < vLMenu.Count)) return;

        vLMenu[(int)LUIMenu.ADDON].SetActive(!vLMenu[(int)LUIMenu.ADDON].activeSelf);
        vLMenu[(int)LUIMenu.INVENTORY].SetActive(!vLMenu[(int)LUIMenu.INVENTORY].activeSelf);
    }

    public void OpenCloseQuest()
    {
        if (!((int)LUIMenu.ADDON < vLMenu.Count || (int)LUIMenu.QUEST < vLMenu.Count)) return;

        vLMenu[(int)LUIMenu.ADDON].SetActive(!vLMenu[(int)LUIMenu.ADDON].activeSelf);
        vLMenu[(int)LUIMenu.QUEST].SetActive(!vLMenu[(int)LUIMenu.QUEST].activeSelf);
    }
}
