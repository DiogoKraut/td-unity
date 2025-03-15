using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Tilemaps;
using HexUtils;

public class PathController : MonoBehaviour
{
    [SerializeField] Tilemap pathMap;
    [SerializeField] GameObject spawner;
    public List<Vector3Int> path;

    void Start()
    {
        Vector3Int startTile = pathMap.WorldToCell(spawner.transform.position);
        path = GetPathOrder(startTile);
    }

    private List<Vector3Int> GetPathOrder(Vector3Int startTile)
    {
        List<Vector3Int> pathTiles = new List<Vector3Int>();
        Vector3Int currentTile = startTile;
        while (currentTile != null)
        {
            bool added = false;
            List<Vector3Int> neighbors = HexGrid.GetNeighbors(currentTile);
            foreach (var neighbor in neighbors)
            {
                TileBase neighborTile = pathMap.GetTile(neighbor);
                if (!neighborTile) continue; // not a tile

                added = PathTileAdd(pathTiles, neighbor);
                if (added)
                {
                    currentTile = neighbor;
                    break;
                }
            }

            if (!added) return pathTiles;
        }
        return pathTiles;
    }

    private bool PathTileAdd(List<Vector3Int> pathTiles, Vector3Int pos)
    {
        foreach (var tile in pathTiles)
        {
            if (tile == pos) return false;
        }

        Debug.Log("added" + pos);
        pathTiles.Add(pos);
        return true;
    }

    void Update()
    {

    }
}
