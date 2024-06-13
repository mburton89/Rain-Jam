using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerV2 : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePrefabs;

    public Transform parent;

    public float obstacleForce = 50f;
    public int xDirection;

    public float minSecondsBetweenSpawns;
    public float maxSecondsBetweenSpawns;

    private void Start()
    {
        StartCoroutine(SpawnSequence());
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject prefabToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
        GameObject newObstacle = Instantiate(prefabToSpawn, spawnPos, transform.rotation, parent);
        newObstacle.GetComponent<Obstacle>().Init(xDirection, obstacleForce);
    }

    private IEnumerator SpawnSequence()
    {
        float randSecondsBetweenSpawns = Random.Range(minSecondsBetweenSpawns, maxSecondsBetweenSpawns);

        yield return new WaitForSeconds(randSecondsBetweenSpawns);

        SpawnEnemy();
        
        StartCoroutine(SpawnSequence());
    }
}