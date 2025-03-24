using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] GameObject storyPanel;
    [TextArea] public List<string> lines = new List<string>();

    private FirstPersonController player;
    private bool inTrigger = false;

    [SerializeField] private bool cockroach;
    [SerializeField] private GameObject cockroachBoss;
    private bool activatedStory;
    private void Start()
    {
        player = FirstPersonController.instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            player.CutsceneMode();
            ShowStory();
        }
    }
    public void ShowStory()
    {
        GameObject sp = Instantiate(storyPanel);
        sp.GetComponent<FadeToBlackText>().lines = lines;
        activatedStory = true;
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            inTrigger = false;
        }
        if (col.CompareTag("Player") && cockroach && activatedStory)
        {
            
            Instantiate(cockroachBoss,transform.position,transform.rotation);
            Destroy(this);
        }
    }
}
