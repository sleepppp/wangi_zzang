using System;
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

    private MoveCtrl moveCtrl;
    private Vector3 moveVector;

    private void Awake()
    {
        ObjcetName = "캐릭터";
        Level = 1;
        Exp = 0;
        MaxExp = Hp = MaxHp = Sp = MaxSp = 50;
        Vit = Str = Stm = Dex = StatPoint = 5;

        moveCtrl = FindObjectOfType<MoveCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        DecreaseHp();
        MoevObject();
    }

    private void MoevObject()
    {
        moveVector.x = moveCtrl.InputVector.x;
        moveVector.z = moveCtrl.InputVector.y;

        transform.Translate(moveVector * 3.0f * Time.deltaTime);
        
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

