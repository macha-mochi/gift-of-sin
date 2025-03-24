using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSetActive : MonoBehaviour
{
    [SerializeField] private GameObject toSetActive;
    [SerializeField] private Transform lookPoint;
    private bool interacted = false;
    private void Start()
    {
    }
    private void Update()
    {
        if (interacted)
        {
            Camera.main.transform.LookAt(lookPoint);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !interacted)
        {
            toSetActive.SetActive(true);
            interacted = true;
            
        }
    }
    public void DestroySelf()
    {
        Destroy(this);
    }
}
