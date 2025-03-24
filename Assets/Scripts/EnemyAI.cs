using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int damage;
    [SerializeField] private int detectDistance = 30;
    private NavMeshAgent agent;

    [SerializeField] private LayerMask interactedLayers;
    private float strayTime = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;

    }
    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position + Vector3.up,  (FirstPersonController.instance.transform.position - (transform.position + Vector3.up)), out hit, 100,interactedLayers);
       
        if (hit.transform.CompareTag("Player"))
        {
            agent.isStopped = false;
            strayTime = 0;
        }
        else
        {
            strayTime += Time.deltaTime;
            if (strayTime > 1)
            {
                agent.isStopped = true;
            }
        }


        agent.destination = GameObject.Find("FirstPersonController").transform.position;

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health.instance.DealDamage(damage);
        }
    }
}
