using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform player;

    [Header("Settings")]
    public int targetCount = 5;
    public float spawnRadius = 20f;
    public float minHeight = 0f;
    public float maxHeight = 5f;

    void Start()
    {
        // Initial spawn of targets
        for (int i = 0; i < targetCount; i++)
        {
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        // Get a random point on a circle around the player
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;

        // Calculate the final coordinates
        float x = player.position.x + randomCircle.x;
        float z = player.position.z + randomCircle.y;
        float y = player.position.y + Random.Range(minHeight, maxHeight);

        Vector3 spawnPos = new Vector3(x, y, z);

        // Create the object
        Instantiate(targetPrefab, spawnPos, Quaternion.identity);
    }

    public void OnTargetDestroyed()
    {
        // When one dies, spawn another to maintain the count
        SpawnTarget();
        // NCHECK potential infection zombie horde whatever by spawning more as they die?
    }
}