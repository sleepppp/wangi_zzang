using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenMgr : MonoBehaviour
{
    private ItemPoolMgr itemPool;
    private GameObject inven;
    private List<GameObject> lItemSlot = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        inven = GameObject.Find("InventoryList");
        itemPool = GameObject.Find("ItemPoolMgr").GetComponent<ItemPoolMgr>();

        SetLlitemSlot();

        StartCoroutine(SetSlot());
    }

    private void SetLlitemSlot()
    {
        for (int i=0; i<inven.transform.childCount; i++)
        {
            lItemSlot.Add(inven.transform.GetChild(i).gameObject);
        }
    }

    IEnumerator SetSlot()
    {
        WaitUntil waitUntil = new WaitUntil(() => this.isActiveAndEnabled);

        itemPool.ActiveItemPool();
        
        for (int i=0; i<itemPool.lItemPool.Count; i++)
        {
            if(lItemSlot[i].transform.childCount == 0)
            itemPool.lItemPool[i].transform.SetParent(lItemSlot[i].transform);
        }

        yield return waitUntil;
    }
    
}
