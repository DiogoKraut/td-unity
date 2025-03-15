using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; 
    [SerializeField] Tilemap path; 

    private List<GameObject> enemies = new List<GameObject>();
    Grid grid;
    void Start()
    {
        grid = GetComponentInParent<Grid>();
        Vector3Int gridPos = grid.WorldToCell(transform.position);
        GameObject o = Instantiate(enemyPrefab, grid.GetCellCenterWorld(gridPos), Quaternion.identity);
        enemies.Add(o);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
