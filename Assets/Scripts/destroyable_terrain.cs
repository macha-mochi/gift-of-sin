using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyable_terrain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionExit(Collision collision) 
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
