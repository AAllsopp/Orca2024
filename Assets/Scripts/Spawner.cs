using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mySphere1;
    public GameObject mySphere2;
    public GameObject mySphere3;

    private GameObject [] spheres;
    
    public void SpawnSphere() {
        int spawnPointX = Random.Range(-20, 20);
        int spawnPointY = Random.Range(20, 30);
        int spawnPointZ = Random.Range(-20, 20);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
        int listRand = Random.Range(1, 3);

        spheres = new GameObject[] {mySphere1, mySphere2, mySphere3};
        Instantiate(spheres[listRand], spawnPosition, Quaternion.identity);
        
        
    }
}
