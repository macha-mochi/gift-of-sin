using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDoors : MonoBehaviour
{
    [SerializeField] GameObject storyPanelPrefab;
    [SerializeField] [TextArea] List<string> lines = new List<string>();

    private bool inTrigger;
    private FirstPersonController player;
    private bool chosenEnding = false;
    private GameObject sp;

    private void Start()
    {
        player = FirstPersonController.instance;
    }
    private void OnTriggerStay(Collider other)
    {
        if (!inTrigger && other.gameObject.CompareTag("Player")) inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            player.CutsceneMode();
            sp = Instantiate(storyPanelPrefab);
            sp.GetComponent<FadeToBlackText>().lines = lines;
            chosenEnding = true;
        }
        if(chosenEnding && !sp.activeInHierarchy)
        {
            SceneManager.LoadScene(2);
            player.CutsceneMode();
            player.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
