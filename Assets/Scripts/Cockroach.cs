using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("WalkRandom", 0, Random.Range(3,5));
    }
    void WalkRandom()
    {
        transform.Rotate(new Vector3(0, Random.Range(0, 361), 0));
    }
}