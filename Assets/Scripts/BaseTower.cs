using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#nullable enable

[RequireComponent(typeof(BaseRange))]
public class BaseTower : MonoBehaviour {
    [SerializeField] public float fireRate = 1; // seconds per shot
    public Vector3Int gridPos;

    [HideInInspector] public BaseRange range;
    private List<BaseEnemy> enemies;
    private float fireDelay = 0;



    void Start() {
        Grid grid = GameObject.Find("Grid").GetComponent<Grid>();
        enemies = GameObject.FindAnyObjectByType<EnemySpawner>().enemies;
        gridPos = grid.WorldToCell(transform.position);
        GetComponents<BaseRange>();
        range = GetComponent<BaseRange>();
        range.GetRange(gridPos);
        range.Show();
    }

    void Update() {
        range.GetRange(gridPos);
        var target = GetTargetEnemy();

        Debug.Log(target);
        if (fireDelay >= fireRate) {
            fireDelay = 0;
            if (target) this.Shoot(target);
            Debug.Log("shoot");
        }
        fireDelay += Time.deltaTime;
    }

    void OnDestroy() {
        range.Hide();
    }

    void Shoot(BaseEnemy target) {
        Destroy(target.gameObject);
    }

    // TODO: use collider for target finding
    public BaseEnemy? GetTargetEnemy() {
        BaseEnemy? target = null;
        foreach (var enemy in enemies) {
            if (range.tiles.Contains(enemy.gridPos)) {
                return enemy;
            }
        }

        return target;
    }
}
