using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover : MonoBehaviour
{
    public float speed;
    public Vector2 directionn;

    void Start()
    {
        Debug.Log("I am alive!");      
    }
  
    void Update()
    {
        Move();
        GetInput();
    }

    public void Move()
    {
        transform.Translate(directionn.normalized * speed * Time.deltaTime);
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
