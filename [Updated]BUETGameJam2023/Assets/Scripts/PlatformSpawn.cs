using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject platformPrefab;
    public float minHeight;
    public float maxHeight;
    public float spawnOffset = 10f; // Distance between each spawned platform
    private float lastSpawnPositionX;

    private void Start()
    {
        lastSpawnPositionX = transform.position.x;
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        // Calculate a random height within the specified range.
        float height = Random.Range(minHeight, maxHeight);

        // Calculate the spawn position along the x-axis
        float spawnPositionX = lastSpawnPositionX + spawnOffset;

        // Instantiate the platform prefab at the calculated position and height.
        GameObject platform = Instantiate(platformPrefab, new Vector3(spawnPositionX, height, 0f), Quaternion.identity);

        // Update the last spawn position
        lastSpawnPositionX = spawnPositionX;
    }
}
