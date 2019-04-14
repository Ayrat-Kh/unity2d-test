using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    public float smoothing;

    public Vector2 MaxPos;

    public Vector2 MinPos;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    private void LateUpdate()
    {
        CameraMover();     
    }

    private void CameraMover()
    {
        if (transform.position != target.position.normalized)
        {
            Vector3 targetposition = new Vector3(target.position.x,
                target.position.y, transform.position.z);

            targetposition.x = Mathf.Clamp(targetposition.x, MinPos.x, MaxPos.x);
            targetposition.y = Mathf.Clamp(targetposition.y, MinPos.y, MaxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetposition, smoothing );
            
        }
    }

}
