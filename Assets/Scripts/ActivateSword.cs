using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSword : MonoBehaviour
{
    [SerializeField] private Collider swordCollider;
    public void ActivateSwordCollider()
    {
        swordCollider.enabled = true;
    }
    public void DeactivateSwordCollider()
    {
        swordCollider.enabled = false;
    }
}
