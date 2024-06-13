using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float growthRate;

    public void Grow()
    {
        transform.localScale += new Vector3(growthRate, growthRate);
    }
}
