using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovePlatform : MonoBehaviour
{
    public Transform target; // the target position
    public float speed; // speed - units per second (gives you control of how fast the object will move in the inspector)
    public bool moveObj; // a public bool that allows you to toggle this script on and off in the inspector

    // Update is called once per frame
    void Update()
    {
        if (moveObj == true)
        {
            float step = speed * Time.deltaTime; // step size = speed * frame time
            transform.position = Vector3.MoveTowards(transform.position, target.position, step); // moves position a step closer to the target position
        }
    }
}
