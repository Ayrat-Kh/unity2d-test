using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover2 : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public Vector3 directionn;
    public Rigidbody rb;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }


    void Start()
    {
        
    }
  
    void FixedUpdate()
    {
        Move();
        GetInput();
    }

    private void AnimateMovement(Vector3 direction)
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("z", direction.z);
    }

    private void Move()
    {
        rb.AddForce(directionn.normalized * speed);

        AnimateMovement(directionn);      
    }
    private void GetInput()
    {
        directionn = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            directionn += Vector3.right;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionn += Vector3.left;
            //anim.Play("left");
        }
        if (Input.GetKey(KeyCode.W))
        {
            directionn += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            directionn += Vector3.back;
        }
    }
}
