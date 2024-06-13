using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody2D rb;

    public void Init(int xDirection, float xSpeed)
    {
        rb.AddForce(new Vector3(xDirection, 0, 0) * xSpeed);
    }
}
