using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public static WaterSpawner Instance;

    public GameObject waterDropPrefab;
    public GameObject toxicWaterDropPrefab;

    public Transform waterSpawnPoint;

    [HideInInspector] public bool canSpawnWater;

    bool hasSpawnedWater;

    public float secondsBeforeSpawn = 0.5f;

    private void Awake()
    {
        Instance = this;
        canSpawnWater = true;
    }

    public void SpawnWaterDrop()
    {
        if (!canSpawnWater || hasSpawnedWater) return;

        StartCoroutine(SpawnWaterBuffer());

        int rand = Random.Range(0, 5);

        if (rand == 0)
        {
            Instantiate(toxicWaterDropPrefab, waterSpawnPoint.position, transform.rotation, transform);
        }
        else
        {
            Instantiate(waterDropPrefab, waterSpawnPoint.position, transform.rotation, transform);
        }
    }

    public void DelaySpawnWaterDrop()
    { 
        StartCoroutine(DelaySpawnCo());
    }

    private IEnumerator DelaySpawnCo()
    { 
        yield return new WaitForSeconds(secondsBeforeSpawn);
        SpawnWaterDrop();
    }

    private IEnumerator SpawnWaterBuffer()
    {
        hasSpawnedWater = true;
        yield return new WaitForSeconds(0.5f);
        hasSpawnedWater = false;
    }
}
