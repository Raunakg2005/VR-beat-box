using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // These create empty slots in Unity where we will drag our Prefabs
    public GameObject redPrefab;
    public GameObject bluePrefab;
    
    // How many seconds between each spawn
    public float spawnInterval = 1.5f; 
    private float timer;

    void Update()
    {
        // This acts as a stopwatch counting up
        timer += Time.deltaTime;

        // When the stopwatch hits our interval, spawn a block and reset!
        if (timer >= spawnInterval)
        {
            SpawnBlock();
            timer = 0f;
        }
    }

    void SpawnBlock()
    {
        // Flip a coin: 0 for Red, 1 for Blue
        int randomCube = Random.Range(0, 2);

        if (randomCube == 0)
        {
            // Spawn Red shifted 0.5 meters to the LEFT
            Vector3 spawnPos = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            Instantiate(redPrefab, spawnPos, transform.rotation);
        }
        else
        {
            // Spawn Blue shifted 0.5 meters to the RIGHT
            Vector3 spawnPos = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            Instantiate(bluePrefab, spawnPos, transform.rotation);
        }
    }
}