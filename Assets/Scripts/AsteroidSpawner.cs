using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnRadius = 100f;
    public float spawnInterval = 2f;
    public float asteroidSpeed = 10f;

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 1f, spawnInterval); // To spawn in every given time i.e 2f
    }

    void SpawnAsteroid()
    {
        // Generate a random position on a sphere
        Vector3 spawnPosition = Random.onUnitSphere * spawnRadius; // Random position around the earth 100f
        // Instantiate the asteroid at the spawn position
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity); // loading prefab in the game 

        // Add velocity toward the Earth's center
        Rigidbody rb = asteroid.AddComponent<Rigidbody>(); // Give rigidbody for gravity and collision
        rb.useGravity = false; 
        rb.linearVelocity = (Vector3.zero - spawnPosition).normalized * asteroidSpeed; // Give it velocity to randomly move towards Earth 
    }
}
