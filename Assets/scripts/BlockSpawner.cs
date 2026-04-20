using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject redPrefab;
    public GameObject bluePrefab;
    
    [Header("Spawn Timing")]
    public float spawnInterval = 1.5f; 
    public float minSpawnInterval = 0.5f; // The fastest it can possibly spawn
    public float speedIncreaseRate = 0.05f; // How much the interval shrinks each time

    // --- NEW: Area Limits for Spawning ---
    // You can change these numbers right inside the Unity Inspector!
    [Header("Spawn Limits")]
    public float lowestY = 0.8f;  // About waist height
    public float highestY = 2.2f; // Just above head height
    public float closestX = 0.2f; // Near the center of your chest
    public float furthestX = 1.2f; // Far out to your sides

    void Start()
    {
        // Start the Coroutine when the spawner activates
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        // Infinite loop to keep spawning while the game runs
        while (true)
        {
            // Wait for the current interval time
            yield return new WaitForSeconds(spawnInterval);
            
            SpawnBlock();

            // Slowly decrease the wait time to spawn faster
            if (spawnInterval > minSpawnInterval)
            {
                spawnInterval -= speedIncreaseRate;
            }
        }
    }

    void SpawnBlock()
    {
        int randomCube = Random.Range(0, 2);

        // 1. Pick a completely random height between our lowest and highest limits
        float randomHeight = Random.Range(lowestY, highestY);
        
        // 2. Pick a completely random side distance between our closest and furthest limits
        float randomWidth = Random.Range(closestX, furthestX);

        if (randomCube == 0) // RED BLOCK
        {
            // 3. Randomly choose whether it spawns on Left or Right (50/50 crossover chance)
            bool spawnOnLeft = Random.value > 0.5f;
            float sideOffset = spawnOnLeft ? -randomWidth : randomWidth;

            // Apply the offset (either negative or positive)
            Vector3 spawnPos = new Vector3(transform.position.x + sideOffset, randomHeight, transform.position.z);
            Instantiate(redPrefab, spawnPos, transform.rotation);
        }
        else // BLUE BLOCK
        {
            // Do the same for the Blue block
            bool spawnOnLeft = Random.value > 0.5f;
            float sideOffset = spawnOnLeft ? -randomWidth : randomWidth;

            Vector3 spawnPos = new Vector3(transform.position.x + sideOffset, randomHeight, transform.position.z);
            Instantiate(bluePrefab, spawnPos, transform.rotation);
        }
    }
}