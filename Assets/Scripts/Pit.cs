using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    [SerializeField] private int damageDealth;
    [SerializeField] private Transform teleportPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            Health.instance.DealDamage(damageDealth);
            other.gameObject.transform.position = teleportPoint.transform.position;
        }
        if (other.CompareTag("Enemy")) {
            other.gameObject.GetComponent<EnemyHealth>().DealDamage(100);
        }
        
    }
}
