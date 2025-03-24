using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    private bool interacting = false;
    private AudioSource audioSource;
    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private ParticleSystem musicParts;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (interacting)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSource.Play();
                musicParts.Play();
                mainMusic.Pause();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interacting = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interacting = false;
        }
    }
}
