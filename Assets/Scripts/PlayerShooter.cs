using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerShooter : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Transform shotpoint;

    private Animator anim;
    private float currentCooldownTimer;
    private bool canShoot = true;
    private AudioSource audioSource;
    [SerializeField] AudioClip gunShot;
    [SerializeField] float volume = 1.0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentCooldownTimer < 0 && canShoot)
        {
            anim.Play("Fire", -1, 0f);
            currentWeapon.Shoot(this);
            currentCooldownTimer = currentWeapon.GetCooldownTime();
            Debug.Log("Fired");
            audioSource.PlayOneShot(gunShot, volume);
        }
        currentCooldownTimer -= Time.deltaTime;
    }
    public void SetShootingState(bool state)
    {
        canShoot = state;
    }
    public Transform GetShotPoint()
    {
        return shotpoint;
    }
}
