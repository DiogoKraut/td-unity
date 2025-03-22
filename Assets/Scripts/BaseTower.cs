using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseRange))]
public class BaseTower : MonoBehaviour
{
    public Vector3Int gridPos;
    public BaseRange range;

    void Start()
    {
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        gridPos = grid.WorldToCell(transform.position);
        GetComponents<BaseRange>();
        range = GetComponent<BaseRange>();
        range.GetRange(gridPos);
        range.Show();
    }

    void Update()
    {
        range.GetRange(gridPos);
    }

}
