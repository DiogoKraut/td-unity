using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using HexUtils;
using System.Numerics;
using System.Threading.Tasks;
using UnityEditor.Rendering;
using NUnit.Framework;

public class CircleRange : BaseRange {
    [SerializeField] public int radius = 1;

    protected override void Start() {
        base.Start();
    }

    public override HashSet<Vector3Int> GetRange(Vector3Int position) {
        tiles.UnionWith(HexGrid.GetNeighbors(position));
        for (int i = 1; i < radius; i++) {
            Parallel.ForEach(tiles, tile => {
                tiles.UnionWith(HexGrid.GetNeighbors(tile));
            });
        }

        return tiles;
    }

    public void ChangeRadius(int value) {
        radius = value;
        // 0.43298835 radius (to top edge) of hex
    }

}
