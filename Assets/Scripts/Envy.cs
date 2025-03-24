using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envy : MonoBehaviour
{
    public static bool talkedTo = false;

    private void Start()
    {

        if (talkedTo)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Sins>().DropArtifact();
        }
    }
    public void SetTalkedToTrue() // to be called by fungus
    {
        talkedTo = true;
    }
}
