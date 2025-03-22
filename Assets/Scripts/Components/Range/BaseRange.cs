using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;


public enum TargetingType {
    Closest,
    Furthest,
    Stronges,
    Weakest,
}
public abstract class BaseRange : MonoBehaviour {
    [SerializeField] protected TileBase rangeIndicator;
    protected Tilemap pathMap;
    protected Tilemap interactiveMap;
    protected Tilemap tilemap;
    protected Grid grid;
    protected bool isDrawn = false;
    public HashSet<Vector3Int> tiles = new HashSet<Vector3Int>();

    protected virtual void Start() {
        grid = GameObject.FindAnyObjectByType<Grid>();
        interactiveMap = GameObject.Find("InteractiveMap").GetComponent<Tilemap>();
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        pathMap = GameObject.Find("Path").GetComponent<Tilemap>();
    }

    public abstract HashSet<Vector3Int> GetRange(Vector3Int position);

    public virtual void Show() {
        if (tiles.Count <= 0) return;

        foreach (var tile in tiles) {
            var pos = new Vector3Int(tile.x, tile.y, 1);
            interactiveMap.SetTile(pos, rangeIndicator);
        }

    }

    public virtual void Hide() {
        if (tiles.Count <= 0) return;

        foreach (var tile in tiles) {
            var pos = new Vector3Int(tile.x, tile.y, 1);
            interactiveMap.SetTile(pos, null);
        }

    }
}
