using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover1 : MonoBehaviour
{
    public float speed;
    public Vector2 directionn;
    public Rigidbody rb;

    void Start()
    {
        
    }
  
    void FixedUpdate()
    {
        Move();
        GetInput();
    }

    public void Move()
    {
        rb.AddForce(directionn.normalized * speed);
        
    }
    private void GetInput()
    {
        directionn = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
        {
            directionn += Vector2.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionn += Vector2.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            directionn += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            directionn += Vector2.down;
        }
    }
}
