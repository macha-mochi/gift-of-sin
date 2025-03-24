using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Open_door[] doors;

    private bool doorsAllowedToOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        doorsAllowedToOpen = true;
    }
    public void DeactivateDoors()
    {
        foreach(Open_door door in doors)
        {
            door.SetDoorStatus(false);
        }
    }
}
