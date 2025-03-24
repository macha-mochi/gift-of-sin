using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_pad : MonoBehaviour
{
    public int Bounce_Force = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        var obj = collision.gameObject.GetComponent<Rigidbody>();
        if (obj != null)
        {
            obj.AddForce(Vector3.up*Bounce_Force, ForceMode.Impulse);
        }
    }
}
