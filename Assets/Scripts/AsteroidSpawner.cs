using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnRadius = 100f;
    public float spawnInterval = 2f;
    public float asteroidSpeed = 10f;

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 1f, spawnInterval);
    }

    void SpawnAsteroid()
    {
        // Generate a random position on a sphere
        Vector3 spawnPosition = Random.onUnitSphere * spawnRadius;
        // Instantiate the asteroid at the spawn position
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Add velocity toward the Earth's center
        Rigidbody rb = asteroid.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearVelocity = (Vector3.zero - spawnPosition).normalized * asteroidSpeed;
    }
}
