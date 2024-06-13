using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public static WaterSpawner Instance;

    public GameObject waterDropPrefab;

    public Transform waterSpawnPoint;

    [HideInInspector] public bool canSpawnWater;

    bool hasSpawnedWater;

    private void Awake()
    {
        Instance = this;
        canSpawnWater = true;
    }

    public void SpawnWaterDrop()
    {
        if (!canSpawnWater || hasSpawnedWater) return;

        StartCoroutine(SpawnWaterBuffer());

        Instantiate(waterDropPrefab, waterSpawnPoint.position, transform.rotation, transform);
    }

    private IEnumerator SpawnWaterBuffer()
    {
        hasSpawnedWater = true;
        yield return new WaitForSeconds(0.5f);
        hasSpawnedWater = false;
    }
}
