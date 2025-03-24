using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public static bool broken = false;
    [SerializeField] GameObject fakeWallpaper;
    [SerializeField] GameObject door;
    private void Start()
    {
        if (broken)
        {
            becomeDoor();
            Destroy(gameObject);
        }
    }
    public void becomeDoor()
    {
        broken = true;
        fakeWallpaper.SetActive(false);
        door.SetActive(true);
    }
}
