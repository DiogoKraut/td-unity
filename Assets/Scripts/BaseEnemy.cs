using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] float speed = 1;

    List<Vector3Int> path;
    private Grid grid;
    private int nextPos = 0;
    private float cellDistance;
    private float startTime;
    void Start()
    {
        grid = GameObject.FindAnyObjectByType<Grid>();
        path = GameObject.FindAnyObjectByType<PathController>().path;
        cellDistance = Vector3.Distance(path[0], path[1]);
        startTime = Time.time;
    }

    void Update()
    {
        if (nextPos >= path.Count)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3Int nextPosCoord = path[nextPos];
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / cellDistance;
        transform.position = Vector3.Lerp(grid.GetCellCenterWorld(path[Mathf.Max(nextPos - 1, 0)]), grid.GetCellCenterWorld(path[nextPos]), fractionOfJourney);

        if (transform.position == grid.GetCellCenterWorld(nextPosCoord))
        {
            nextPos += 1;
            startTime = Time.time;
        }
    }
}
