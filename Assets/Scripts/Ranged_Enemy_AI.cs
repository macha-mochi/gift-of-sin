using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Ranged_Enemy_AI : MonoBehaviour
{
    [Header("Attributes")]


    [SerializeField] private float attackCooldown;
    [SerializeField] private LayerMask interactedLayers;
    private float attackCurrentCooldown;

    private float teleportCooldown = 2.5f;
    private float teleCooldownCounter;
    [Space(10)]
    //Components
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent ai;

    public bool isAttacking = false;
    public bool flyPhase = false;

    private float flyCooldown = 20f;
    private float flyCooldownCounter = 10;

    private float bulletCooldown = 2f;
    private float bulletCooldownCounter;

    private float flyingCooldown = 5;
    private float flyingCooldownCounter;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;

    [SerializeField] GameObject endingVN;
    [SerializeField] GameObject healthbar;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        ai = GetComponentInChildren<NavMeshAgent>();
        anim.SetBool("Walk", true);
    }
    private void Update()
    {
        transform.LookAt(FirstPersonController.instance.transform);
        if (bulletCooldownCounter <= 0)
        {
                shotPoint.forward = FirstPersonController.instance.transform.position - shotPoint.position;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                bulletCooldownCounter = bulletCooldown;
        }

        bulletCooldownCounter -= Time.deltaTime;
        RaycastHit hit;
        Physics.Raycast(transform.position + Vector3.up, (FirstPersonController.instance.transform.position - (transform.position + Vector3.up)), out hit, 100, interactedLayers);
    }

}
