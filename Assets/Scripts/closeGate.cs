using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGate : MonoBehaviour
{
    public bool gateClosed = false;
    public RoomManager doors;


    void OnTriggerEnter(Collider doorCheck)
    {
        gateClosed = true;
        doors.DeactivateDoors();
        GetComponent<Animator>().SetBool("gateClosed", gateClosed);

    }
    void OnTriggerExit(Collider doorCheck)
    {
        gateClosed = false;
        GetComponent<Animator>().SetBool("gateClosed", gateClosed);
    }

}