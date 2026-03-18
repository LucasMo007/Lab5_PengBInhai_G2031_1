using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject fallingObjectPrefab; // Assign your prefab in the Inspector
    public float spawnInterval = 1.5f;     // Time between spawns
    public float spawnRangeX = 7f;         // Horizontal range for random spawn positions

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        // Random X position within range, Y at the top of the screen
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
    }
}

