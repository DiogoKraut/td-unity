using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using HexUtils;
using System.Numerics;
using System.Threading.Tasks;

public class CircleRange : BaseRange
{
    [SerializeField] int radius = 1;


    protected override void Start()
    {
        base.Start();
    }

    public override HashSet<Vector3Int> GetRange(Vector3Int position)
    {
        tiles.UnionWith(HexGrid.GetNeighbors(position));
        for (int i = 1; i < radius; i++)
        {
            Parallel.ForEach (tiles, tile =>
            {
                tiles.UnionWith(HexGrid.GetNeighbors(tile));
            });
        }

        return tiles;
    }
}
