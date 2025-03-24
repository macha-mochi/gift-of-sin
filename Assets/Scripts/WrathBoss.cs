using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class WrathBoss : MonoBehaviour
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

    private float bulletCooldown = .5f;
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
        if (flyPhase)
        {
            transform.LookAt(FirstPersonController.instance.transform);
            if (bulletCooldownCounter <= 0)
            {
                shotPoint.forward = FirstPersonController.instance.transform.position - shotPoint.position;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                bulletCooldownCounter = bulletCooldown;
            }
            
            if(flyingCooldownCounter <= 0)
            {
                flyPhase = false;
                Debug.Log("Flying stopped");
                anim.SetBool("Flying", false);
                ai.enabled = true;
                flyCooldownCounter = 10;
                flyingCooldownCounter = 5;
            }
            
            bulletCooldownCounter -= Time.deltaTime;
            flyingCooldownCounter -= Time.deltaTime;
        }

        
        RaycastHit hit;
        Physics.Raycast(transform.position + Vector3.up, (FirstPersonController.instance.transform.position - (transform.position + Vector3.up)), out hit, 100, interactedLayers);

        if (!flyPhase && hit.transform != null && hit.transform.CompareTag("Player"))
        {
            healthbar.SetActive(true);
            ai.destination = FirstPersonController.instance.transform.position;
            if (attackCurrentCooldown <= 0)
            {
                if (ai.remainingDistance < 2)
                {
                    SliceAttack();
                    if (Random.Range(1, 3) == 1)
                    {
                        SwipeAttack();
                    }
                }
                if (ai.remainingDistance > 15)
                {
                    if (teleCooldownCounter < 0)
                    {
                        teleCooldownCounter = teleportCooldown;
                        Teleport();
                    }

                }

                attackCurrentCooldown = attackCooldown;
            }
            if(flyCooldownCounter <= 0 )
            {
                Debug.Log("Flying cooldown!");
                flyCooldownCounter = flyCooldown;
                ProjectilePhase();
                flyPhase = true;
            }
        }
        teleCooldownCounter -= Time.deltaTime;
        attackCurrentCooldown -= Time.deltaTime;
        flyCooldownCounter -= Time.deltaTime;


    }
    
    private void SliceAttack()
    {
        anim.SetTrigger("Slice");
    }
    private void SwipeAttack()
    {
        anim.SetTrigger("Swirl");
    }
    private void Teleport()
    {
        transform.position = FirstPersonController.instance.transform.position + (Vector3.forward * Random.Range(-.5f, .5f)) + (Vector3.right * Random.Range(-.5f, .5f));
    }
    private void ProjectilePhase()
    {
        anim.SetBool("Flying", true);
        ai.enabled = false;
        transform.Translate(transform.up * 7);
        flyingCooldownCounter = flyingCooldown;
    }
    
    public void TriggerEndingVN()
    {
        Debug.Log("ending triggered");
        endingVN.transform.parent = null;
        endingVN.SetActive(true);
    }
}
