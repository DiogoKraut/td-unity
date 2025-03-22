using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Tilemaps;

public class GridController : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tilemap interactiveTilemap;
    [SerializeField] private Tilemap pathMap;
    [SerializeField] private TileBase hoverTile;
    [SerializeField] private GameObject baseTower;

    private Grid grid;
    private Vector3Int currentTilePos = new Vector3Int(0, 0, 0);
    private Dictionary<Vector3Int, BaseTower> towers = new Dictionary<Vector3Int, BaseTower>();
    void Start()
    {
        grid = GetComponent<Grid>();
    }

    void Update()
    {
        UserMapUpdate();
    }

    private void UserMapUpdate()
    {
        // Hover behaviour
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int coordinate = GetGridCoordinate(mouseWorldPos);
        TileBase t = tilemap.GetTile(coordinate);
        if (coordinate != currentTilePos)
        {
            if (t != null)
            {
                interactiveTilemap.SetTile(coordinate, hoverTile);

            }
            interactiveTilemap.SetTile(currentTilePos, null);
        }
        currentTilePos = coordinate;


        if (Input.GetMouseButtonDown(0))
        {
            if (towers.ContainsKey(coordinate) && t)
            {
                towers[coordinate].range.GetRange(coordinate);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (!pathMap.GetTile(coordinate))
            {
                if (!towers.ContainsKey(coordinate) && t)
                {
                    GameObject tow = Instantiate(baseTower, GetWorldCoordinate(coordinate), Quaternion.identity);
                    towers.Add(coordinate, tow.GetComponent<BaseTower>());
                }
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (towers.ContainsKey(coordinate))
            {
                BaseTower tow = null;
                towers.Remove(coordinate, out tow);
                Destroy(tow.gameObject);
            }
        }
    }

    private Vector3Int GetGridCoordinate(Vector3 position)
    {
        Vector3Int coordinate = grid.WorldToCell(position);
        return new Vector3Int(coordinate.x, coordinate.y, 0);
    }

    private Vector3 GetWorldCoordinate(Vector3Int position)
    {
        return grid.GetCellCenterWorld(position);
    }
}
