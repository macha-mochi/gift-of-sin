using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public abstract class Weapon : MonoBehaviour
{
    protected enum WEAPON_TYPE { Hitscan,Projectile}
    [Header("Attributes")]
    [SerializeField] protected string      weaponName;
    [SerializeField] protected WEAPON_TYPE weaponType;
    [SerializeField] protected float cooldownTime;
    [SerializeField] protected float damage; 

    [Space(10)]
    [Header("Only Projectile Weapons")]
    [SerializeField] protected GameObject projectile;

    [Space(10)]
    [Header("Only Hitscan Weapons")]
    [SerializeField] protected LineRenderer trailPrefab;
    [SerializeField] protected ParticleSystem hitParticles;

    [SerializeField] protected LayerMask layer;
    [SerializeField] protected LayerMask enemyLayer;

    [SerializeField] protected CinemachineImpulseSource source;

    private PlayerShooter ps;
    private RaycastHit hit;
    LineRenderer trail;
    private void Start()
    {
        source = transform.root.GetComponent<CinemachineImpulseSource>();
    }
    public virtual void Shoot(PlayerShooter ps)
    {
            this.ps = ps;
            ShootTrail();
    }
    public float GetCooldownTime()
    {
        return cooldownTime;
    }
    public void ShootTrail()
    {
        Vector3 shotPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        var cast = Physics.Raycast(shotPos, Camera.main.transform.forward, out hit, Mathf.Infinity,layer);
        if (hit.distance == 0) { hit.distance = 100; }
        trail = Instantiate(trailPrefab, transform.parent.position, Quaternion.identity);
        trail.SetPosition(0, trail.transform.InverseTransformPoint(ps.GetShotPoint().position));
        trail.SetPosition(1, trail.transform.InverseTransformPoint(hit.point));
        if (hit.transform.gameObject.CompareTag("Enemy"))
        {
            
            hit.transform.GetComponent<EnemyHealth>().DealDamage(damage);

            source.GenerateImpulse();
        }
    }
}
