using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public Vector3 pos = new Vector3(-4, 0, 0);
    public float size = 1.0f;
    private Vector3 dir = Vector3.right;

    public GameObject[] endPoint;


    public Transform target; // the target position
    public float speed; // speed - units per second (gives you control of how fast the object will move in the inspector)
    public bool moveObj; // a public bool that allows you to toggle this script on and off in the inspector


    void Start()
    {
        StartCoroutine(Spawn());
    }



    // Update is called once per frame
    void Update()
    {

    }



    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(obj[Random.Range(0, obj.Length)], pos, Quaternion.identity);
            
            float step = speed * Time.deltaTime; // step size = speed * frame time
            obj[0].transform.position = Vector3.MoveTowards(transform.position, target.position, step); // moves position a step closer to the target position
          
            pos += dir * size;
            yield return new WaitForSeconds(Random.Range(spawnMin, spawnMax));
        }
    }

   


}
