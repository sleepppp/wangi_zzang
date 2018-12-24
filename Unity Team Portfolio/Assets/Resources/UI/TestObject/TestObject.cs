using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    // 오브젝트 속성
    [HideInInspector]
    public string ObjcetName { get; set; }
    [HideInInspector]
    public int Level { get; set; }
    [HideInInspector]
    public int Exp { get; set; }
    [HideInInspector]
    public int MaxExp { get; set; }
    [HideInInspector]
    public int Hp { get; set; }
    [HideInInspector]
    public int MaxHp { get; set; }
    [HideInInspector]
    public int Sp { get; set; }
    [HideInInspector]
    public int MaxSp { get; set; }
    [HideInInspector]
    public int Vit { get; set; }
    [HideInInspector]
    public int Str { get; set; }
    [HideInInspector]
    public int Stm { get; set; }
    [HideInInspector]
    public int Dex { get; set; }
    [HideInInspector]
    public int StatPoint { get; set; }

    private void Awake()
    {
        ObjcetName = "캐릭터";
        Level = 1;
        Exp = 0;
        MaxExp = Hp = MaxHp = Sp = MaxSp = 50;
        Vit = Str = Stm = Dex = StatPoint = 5;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHp();
    }

    public void DecreaseHp()
    {
        if (Hp < 0) return;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Hp -= 1;
        }
    }
}

