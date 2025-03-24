using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_door : MonoBehaviour
{
    public Transform doorCheck;

    private bool doorOpen = false;
    private AudioSource audioSource;
    [SerializeField] AudioClip door;
    [SerializeField] float volume = 1.0f;


    // Update is called once per frame
    private bool inTrigger = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            doorOpen = !doorOpen;
            GetComponent<Animator>().SetBool("OpenDoor", doorOpen);
            Debug.Log("Door OPEN");
            audioSource.PlayOneShot(door, volume);
        }
        
    }
    public void SetDoorStatus(bool state)
    {
        GetComponent<SphereCollider>().enabled = state;
    }
    
    void OnTriggerStay(Collider doorCheck)
    {
        if (doorCheck.gameObject.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    public bool getDoorState()
    {
        return doorOpen;
    }
}
