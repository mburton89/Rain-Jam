using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float growthRate;

    public void Grow()
    {
        transform.localPosition += new Vector3(0, growthRate);
    }
}
