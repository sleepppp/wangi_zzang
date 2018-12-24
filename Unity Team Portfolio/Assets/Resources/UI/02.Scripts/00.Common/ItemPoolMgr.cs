using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPoolMgr : MonoBehaviour
{
    public GameObject item;
    public List<GameObject> lItemPool = new List<GameObject>();

    private readonly int itemQuantity = 10;

    public void Awake()
    {
        CreateItemPool();
    }

    public void CreateItemPool()
    {
        for (int i = 0; i < itemQuantity; i++)
        {
            lItemPool.Add(Instantiate(item, transform));
            lItemPool[i].SetActive(false);
        }
    }

    public void ActiveItemPool()
    {
        for (int i = 0; i<lItemPool.Count; i++)
        {
            lItemPool[i].SetActive(true);
        }
    }
}
