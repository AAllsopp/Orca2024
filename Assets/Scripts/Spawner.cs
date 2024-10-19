using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mySphere;

    public void SpawnSphere() {
        int spawnPointX = Random.Range(-10, 10);
        int spawnPointY = Random.Range(10, 20);
        int spawnPointZ = Random.Range(-10, 10);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(mySphere, spawnPosition, Quaternion.identity);
    }
}
