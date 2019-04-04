using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public CharacterController controller;
    public float speed = 10.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Transform trans;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        trans = GameObject.Find("P1/default").gameObject.transform;
    } 
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        RotateView();
    }
    public void RotateView()
    {
        float rot = Mathf.Clamp(Input.GetAxis("Mouse X"), -360f, 360f);
        trans.Rotate(trans.up, rot);
        //Debug.Log(trans.position+"111");
        //Debug.Log(trans.localPosition + "222"); 
    }

}
