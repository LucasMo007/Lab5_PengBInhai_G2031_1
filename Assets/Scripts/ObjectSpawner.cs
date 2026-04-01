using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject fallingObjectPrefab;  // Normal collectible prefab
    public GameObject bombPrefab;           // Bomb prefab
    public float spawnInterval = 1.5f;
    public float spawnRangeX = 7f;

    [Header("Bomb Settings")]
    [Range(0f, 1f)]
    public float bombChance = 0.2f;  // 20% chance to spawn a bomb

    private float timer;

    void Update()
    {
        // Don't spawn if game is over
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        // Randomly decide if this is a bomb or a normal object
        if (Random.value < bombChance)
        {
            // Spawn bomb
            GameObject bomb = Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
            FallingObject fo = bomb.GetComponent<FallingObject>();
            if (fo != null)
            {
                fo.SetAsBomb(true);
            }
        }
        else
        {
            // Spawn normal collectible
            Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
