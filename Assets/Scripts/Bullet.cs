using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 5;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Health.instance.DealDamage(damage);
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        if(Vector3.Distance(FirstPersonController.instance.transform.position, transform.position) > 5) rb.velocity = (FirstPersonController.instance.transform.position - transform.position).normalized * speed;
    }
}
