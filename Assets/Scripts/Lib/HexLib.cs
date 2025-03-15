using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUtils
{
    /// <summary>
    /// A utility class for working with hexagonal grids.
    /// </summary>
    public class HexGrid
    {
        static readonly List<Vector3Int> evenNeighbors = new List<Vector3Int> {
            new Vector3Int(1, 0, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(0, 1, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(-1, 1, 0),
            new Vector3Int(-1, -1, 0)
        };

        static readonly List<Vector3Int> oddNeighbors = new List<Vector3Int> {
            new Vector3Int(1, 0, 0),
            new Vector3Int(-1, 0, 0),
            new Vector3Int(1, 1, 0),
            new Vector3Int(1, -1, 0),
            new Vector3Int(0, 1, 0),
            new Vector3Int(0, -1, 0)
        };

        /// <summary>
        /// Gets the neighboring tiles for a given position in a hexagonal grid.
        /// </summary>
        /// <param name="pos">The position of the tile.</param>
        /// <returns>A list of neighboring tile positions.</returns>
        public static List<Vector3Int> GetNeighbors(Vector3Int pos)
        {
            List<Vector3Int> neighbors = new List<Vector3Int>();
            if (pos.y % 2 == 0)
            {
                foreach (var neighbor in evenNeighbors)
                {
                    neighbors.Add(pos + neighbor);
                }
            }
            else
            {
                foreach (var neighbor in oddNeighbors)
                {
                    neighbors.Add(pos + neighbor);
                }
            }

            return neighbors;
        }
    }
}