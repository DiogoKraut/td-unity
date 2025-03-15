using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Vector3Int gridPos;


    void Start()
    {
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        gridPos = grid.WorldToCell(transform.position);
    }

    void Update()
    {
        
    }
}
