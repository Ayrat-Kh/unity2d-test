using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ded : MonoBehaviour
{
    public Transform target;

    private float xMin, xMax, yMin, yMax;

    [SerializeField]
    private Tilemap tilemap;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 minSquare = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxSquare = tilemap.CellToWorld(tilemap.cellBounds.max);

        SetLimits(minSquare, maxSquare);
    }


    private void LateUpdate()
    {
        

        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), -10);
    }

    private void SetLimits(Vector3 minSquare, Vector3 maxSquare)
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;

        float Width = height * cam.aspect;

        xMin = minSquare.x + Width / 2;
        xMax = maxSquare.x - Width / 2;

        yMin = minSquare.y + height / 2;
        yMax = maxSquare.y - height / 2;
    }
}

