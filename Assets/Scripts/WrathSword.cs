using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathSword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Health.instance.DealDamage(20);
        }

    }
}
