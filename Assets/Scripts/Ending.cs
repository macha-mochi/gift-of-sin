using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] Transform teleportLocation;
    [SerializeField] Transform lookPoint;

    public void TeleportPlayerToEndingRoom() //to be called by fungus
    {
        Debug.Log("teleported");
        UICanvas.instance.clearDamageScreen();
        GameObject player = FirstPersonController.instance.gameObject;
        player.transform.position = teleportLocation.position;
        Camera.main.transform.LookAt(lookPoint);
    }
    public void DeactivateVN() //to be called by fungus
    {
        gameObject.SetActive(false);
    }
}
