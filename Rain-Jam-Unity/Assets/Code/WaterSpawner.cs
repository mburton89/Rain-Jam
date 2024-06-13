using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public static WaterSpawner Instance;

    public GameObject waterDropPrefab;

    public Transform waterSpawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnWaterDrop()
    { 
        Instantiate(waterDropPrefab, waterSpawnPoint.position, transform.rotation, transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
