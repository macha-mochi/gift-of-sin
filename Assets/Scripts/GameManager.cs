using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null) instance = this;
    }
    public void CutsceneMode()
    {
        FirstPersonController.instance.CutsceneMode();
    }
    public void DeactivateCutsceneMode()
    {
        FirstPersonController.instance.DeactivateCutsceneMode();
    }
}
