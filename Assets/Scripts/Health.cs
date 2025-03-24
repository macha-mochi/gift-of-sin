using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static Health instance;
    [Header("Health")]
    [SerializeField] private int currentHealth = 100;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private CanvasGroup deathScreen;
    [SerializeField] private Image damageScreen;

    private float damageCooldown = 1f;
    private float currentDamageCooldown;
    private bool invincible = false;

    private bool canBeDamaged = true;

    private bool damaged = false;

    private bool isDead = false;

    private float a = 0;
    private float b = 1;

    private float t1;
    public Vector3 savePoint;

    private AudioSource audioSource;
    [SerializeField] AudioClip playerHurt;
    [SerializeField] float volume = 1.0f;

    [SerializeField] Animator damageScreenAnim; 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        UpdateHealthText();
        audioSource = GetComponent<AudioSource>();
    }
   public void SetInvincibleState(bool state)
    {
        invincible = state;
    }
    private void Update()
    {
        if(currentDamageCooldown <= 0)
        {
            currentDamageCooldown = damageCooldown;
            canBeDamaged = true;
        }
        currentDamageCooldown -= Time.deltaTime;
        if (isDead)
        {
            deathScreen.alpha = Mathf.Lerp(a, b, t1);
            t1 += Time.deltaTime * 2;
            FirstPersonController.instance.Die();
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (savePoint != null) transform.position = savePoint;
                else SceneManager.MoveGameObjectToScene(FirstPersonController.instance.gameObject, SceneManager.GetActiveScene());
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                currentHealth = 100;
                FirstPersonController.instance.Revive();
                deathScreen.alpha = 0;
                isDead = false;
                UpdateHealthText();
            }
        }
        if (damaged)
        {
            audioSource.PlayOneShot(playerHurt, volume);
            damageScreenAnim.SetTrigger("Damaged");
            damaged = false;
        }
        

    }
    public int GetHealth()
    {
        return currentHealth;
    }
    public void HealHealth(int damage)
    {
        currentHealth += damage;
        UpdateHealthText();
    }
    public void DealDamage(int damage)
    {
        if (canBeDamaged && !invincible)
        {
            currentHealth -= damage;
            damaged = true;
            if (currentHealth <= 0)
            {
                print("Dead");
                isDead = true;
                currentHealth = 0;
                
            }
            UpdateHealthText();
            canBeDamaged = false;
        }
    }
    public void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
        slider.value = currentHealth;
    }
}
