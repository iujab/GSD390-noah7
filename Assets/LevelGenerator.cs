using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject wallPrefab;

    // Generation settings
    public float distanceToSpawn = 100f;
    public float distanceBetweenObstacles = 20f;
    public float spawnZ = 40f;

    // Difficulty
    public float minGap = 1.2f;
    public float maxGap = 3.5f;

    private List<GameObject> activeWalls = new List<GameObject>();

    void Update()
    {
        if (player == null) return;

        // Generate level ahead of player
        if (player.position.z > spawnZ - distanceToSpawn)
        {
            SpawnObstacleRow();
            spawnZ += distanceBetweenObstacles;
        }

        // We loop backwards because we are removing items from the list
        for (int i = activeWalls.Count - 1; i >= 0; i--)
        {
            if (activeWalls[i] == null)
            {
                activeWalls.RemoveAt(i);
                continue;
            }

            // If the wall is more than 100 units behind the player
            if (activeWalls[i].transform.position.z < player.position.z - 100f)
            {
                Destroy(activeWalls[i]);
                activeWalls.RemoveAt(i);
            }
        }
    }

    void SpawnObstacleRow()
    {
        float gapSize = Random.Range(minGap, maxGap);
        float centerOffset = Random.Range(-3f, 3f);

        Vector3 leftPos = new Vector3(centerOffset - (gapSize / 2) - 5, 1, spawnZ);
        GameObject leftWall = Instantiate(wallPrefab, leftPos, Quaternion.identity);
        leftWall.transform.localScale = new Vector3(10, 2, 1);

        Vector3 rightPos = new Vector3(centerOffset + (gapSize / 2) + 5, 1, spawnZ);
        GameObject rightWall = Instantiate(wallPrefab, rightPos, Quaternion.identity);
        rightWall.transform.localScale = new Vector3(10, 2, 1);

        activeWalls.Add(leftWall);
        activeWalls.Add(rightWall);
    }
}