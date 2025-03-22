using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Tilemap path;

    public List<BaseEnemy> enemies = new List<BaseEnemy>();
    Grid grid;

    private float delay = 0.25F;
    private float elapsed = 0;
    private Vector3Int gridPos;
    void Start() {
        grid = GetComponentInParent<Grid>();
        gridPos = grid.WorldToCell(transform.position);
        GameObject o = Instantiate(enemyPrefab, grid.GetCellCenterWorld(gridPos), Quaternion.identity);
        enemies.Add(o.GetComponent<BaseEnemy>());
    }

    void Update() {
        if (elapsed >= delay) {
            GameObject o = Instantiate(enemyPrefab, grid.GetCellCenterWorld(gridPos), Quaternion.identity);
            enemies.Add(o.GetComponent<BaseEnemy>());
            elapsed = 0;
        }
        elapsed += Time.deltaTime;

    }

    public void RemoveMember(BaseEnemy enemy) {
        enemies.Remove(enemy);
    }
}
