using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour {

    private Vector3 saveMouse;
    [SerializeField]
    private float speed;

	void Start ()
    {
        this.saveMouse = Input.mousePosition;
    }

	void Update ()
    {
        Vector3 moveData = new Vector3(0.0f, 0.0f, 0.0f);
        Vector2 rotateData = new Vector2(0.0f, 0.0f);

        if (Input.GetKey(KeyCode.A))
            moveData += -this.transform.right;
        else if (Input.GetKey(KeyCode.D))
            moveData += this.transform.right;
        if (Input.GetKey(KeyCode.W))
            moveData += this.transform.forward;
        else if (Input.GetKey(KeyCode.S))
            moveData += -this.transform.forward;
        if (Input.GetKey(KeyCode.Q))
            moveData += -this.transform.up;
        else if (Input.GetKey(KeyCode.E))
            moveData += this.transform.up;

        if (Input.anyKey)
        {
            this.transform.Translate(moveData * speed * Time.deltaTime);
        }

        this.saveMouse = Input.mousePosition;

    }
}
