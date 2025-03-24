using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pride : MonoBehaviour
{
    public static bool talkedTo = false;

    private void Update()
    {
        if (talkedTo)
        {
            gameObject.SetActive(false);
        }
    }
    public void SetTalkedToTrue() // to be called by fungus
    {
        talkedTo = true;
    }
}
