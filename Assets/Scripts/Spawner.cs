using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mySphere1;
    public GameObject mySphere2;
    public GameObject mySphere3;

    private GameObject [] spheres;
    
    public void SpawnSphere() {
        Vector3 playerPos = FindFirstObjectByType<character>().getPos();
        int spawnPointX = Random.Range(-20, 20);
        int spawnPointY = Random.Range(-20, 30);
        int spawnPointZ = Random.Range(-20, 20);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ) + playerPos;
        
        Vector3 playerSize = FindFirstObjectByType<character>().getSize();

        spheres = new GameObject[] {mySphere1, mySphere2, mySphere3};
        // Logic to increase the chances based on player size
        GameObject sphereToSpawn;
        if (playerSize.x < 2)
        {
            // Increase likelihood of smaller sphere
            int rand = Random.Range(0, 100); // Generate a random number from 0 to 99
            if (rand < 60) 
            {
                sphereToSpawn = mySphere1; // 60% chance for small sphere
            }
            else if (rand < 90)
            {
                sphereToSpawn = mySphere2; // 30% chance for medium sphere
            }
            else
            {
                sphereToSpawn = mySphere3; // 10% chance for large sphere
            }
        }
        else if (playerSize.x > 2)
        {
            // Increase likelihood of larger sphere
            int rand = Random.Range(0, 100);
            if (rand < 20)
            {
                sphereToSpawn = mySphere1; // 20% chance for small sphere
            }
            else if (rand < 60)
            {
                sphereToSpawn = mySphere2; // 40% chance for medium sphere
            }
            else
            {
                sphereToSpawn = mySphere3; // 40% chance for large sphere
            }
        }
        else
        {
            // If player's size is exactly 2, use default even distribution
            int listRand = Random.Range(0, spheres.Length);
            sphereToSpawn = spheres[listRand];
        }
        Instantiate(sphereToSpawn, spawnPosition, Quaternion.identity);
        
        
    }
}
