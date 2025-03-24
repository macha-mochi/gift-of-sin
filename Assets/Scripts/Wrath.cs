using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrath : MonoBehaviour
{
    [SerializeField] GameObject wrathBoss;
    public static bool talkedTo = false;

    private void Start()
    {
        if (talkedTo)
        {
            wrathBoss.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void SetTalkedToTrue() // to be called by fungus
    {
        talkedTo = true;
    }
    public void SetBossActive() //fungus
    {
        wrathBoss.SetActive(true);
    }
}
