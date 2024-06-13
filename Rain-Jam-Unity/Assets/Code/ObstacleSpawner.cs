using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //Variables
    public int timeEnd;
    public int randSpawnMin = 1;
    public int randSpawnMax = 10;
    public GameObject platform;
    public Rigidbody2D rg2D;

    public Transform target; // the target position
    





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime < timeEnd)
        {
            ObstacleSpawn();
        }
       
        
    }

    public void ObstacleSpawn()
    {
        
  
            int platformNumberSpwaned =  Random.Range(randSpawnMin, randSpawnMax);
            for(int i = 0; i < platformNumberSpwaned; i++)
            {
                Instantiate(platform);
            }
           if (Time.time == 0 && platform.transform.position == target.position)
            {
                for(int i = 0;i < platformNumberSpwaned; i++)
                {
                    Destroy(platform);
                }
            }
    }


}
