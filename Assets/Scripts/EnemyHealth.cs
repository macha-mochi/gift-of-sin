using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] private float currentEnemyHealth = 20;
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private ParticleSystem bloodSplatter;
    private float maxEnemyhealth;
    public bool agro = false;
    private AudioSource audioSource;
    [SerializeField] AudioClip enemyHurt;
    [SerializeField] float volume = 1.0f;

    [SerializeField] private Slider healthbar;

    private void Start()
    {
        maxEnemyhealth = currentEnemyHealth;

        if (healthbar != null) healthbar.maxValue = maxEnemyhealth;
    }
    public void DealDamage(float damage)
    {
        currentEnemyHealth -= damage;
        agro = true;
        if (healthbar != null)
        {
            healthbar.value = currentEnemyHealth;
        }

        if (currentEnemyHealth <= 0)
        {
            //Enemy dead
            if (bloodSplatter != null)
            {
                Instantiate(bloodSplatter, transform.position + Vector3.up * 4, transform.rotation);
                if(ragdoll!= null)
                     Instantiate(ragdoll, transform.position, transform.rotation);
                
            }
            if(GetComponent<Cockroach>() != null)
            {
                FirstPersonController.instance.numCockroachesLeft--;
                if(FirstPersonController.instance.numCockroachesLeft == 0)
                {
                    SceneManager.LoadScene(3);
                }
            }
            if(GetComponent<CockroachBoss>() != null)
            {
                GetComponent<CockroachBoss>().Defeated();
            }
            if (GetComponent<Breakable>() != null)
            {
                GetComponent<Breakable>().becomeDoor();
            }
            if (GetComponent<WrathBoss>() != null)
            {
                GetComponent<WrathBoss>().TriggerEndingVN();
                FirstPersonController.instance.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            Destroy(gameObject);
        }
    }
    public void HealHealth(float health)
    {
        if (health + currentEnemyHealth > maxEnemyhealth)
            currentEnemyHealth = maxEnemyhealth;
        else
            currentEnemyHealth += health;
    }
 }
