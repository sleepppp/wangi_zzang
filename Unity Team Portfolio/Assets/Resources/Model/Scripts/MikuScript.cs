using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikuScript : MonoBehaviour
{

    [SerializeField, Range(1.0f, 6f)]
    private float _rotateSpeed = 1.0f;


    private float _mass;

    Animator _animator;
    Rigidbody rigid;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        AnimationClip clip = null;
        clip = _animator.GetClip("Jump");
        clip.AddEvent("Jumping", 26);

        rigid = this.GetComponent<Rigidbody>();
        _mass = rigid.mass;

    }

    private void Jumping()
    {       
        rigid.AddForce(Vector3.up * 4.0f * _mass * 0.5f, ForceMode.Impulse);
    }

    void Start()
    {

    }


    void Update()
    {
        Moving();


    }

    private void Moving()
    {
        if (_animator)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) _animator.SetBool("Run", true);
            else if (Input.GetKeyUp(KeyCode.LeftShift)) _animator.SetBool("Run", false);


            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if(v >= 0)
            {
                _animator.SetFloat("Speed", h * h + v * v);
                _animator.SetFloat("Direction", h, 0.25f, Time.deltaTime);
            }

            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Base Layer.Walk") || stateInfo.IsName("Base Layer.Run") || stateInfo.IsName("Base Layer.Idle"))
            {
                if (Input.GetKeyDown(KeyCode.Space)) //&& _animator.GetBool("Jump") == false
                {
                    _animator.SetTrigger("Test");

                }

            }

            float angle = 0.0f;

            if (h > 0) angle = 1 * _rotateSpeed;
            if (h < 0) angle = -1 * _rotateSpeed;

            float tempY = this.transform.rotation.eulerAngles.y;
            this.transform.rotation = Quaternion.RotateTowards
            (
                this.transform.rotation, Quaternion.Euler(0, tempY + angle, 0), Time.deltaTime * 120
            );
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _animator.SetTrigger("Jump");
        //}

        //float x = Input.GetAxis("Horizontal") * _maxSpeed * Time.deltaTime;
        //float z = Input.GetAxis("Vertical") * _maxSpeed * Time.deltaTime;

        //bool bWalk = Mathf.Abs(x) > 0 || Mathf.Abs(z) > 0;

        //if (bWalk == true)
        //{
        //    float angle = 0.0f;

        //    if (x > 0) angle = 90;
        //    if (x < 0) angle = -90;
        //    if (z > 0) angle = 0;
        //    if (z < 0) angle = 180;

        //    if (z > 0 && x > 0) angle = 45;
        //    if (z > 0 && x < 0) angle = -45;
        //    if (z < 0 && x < 0) angle = 225;
        //    if (z < 0 && x > 0) angle = -225;

        //    this.transform.rotation = Quaternion.RotateTowards
        //    (
        //        this.transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * 120
        //    );
        //}


    }
}
