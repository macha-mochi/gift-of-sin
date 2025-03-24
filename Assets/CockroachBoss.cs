using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CockroachBoss : MonoBehaviour
{
    [SerializeField] GameObject storyPanel;
    [TextArea] public List<string> lines = new List<string>();

    private FirstPersonController player;

    private void Start()
    {
        player = FirstPersonController.instance;
    }
    public void Defeated()
    {
        UICanvas.instance.clearDamageScreen();
        player.CutsceneMode();
        GameObject sp = Instantiate(storyPanel);
        sp.GetComponent<FadeToBlackText>().lines = lines;
        sp.transform.parent = null;
        sp.GetComponent<FadeToBlackText>().cockroachBoss = true;
        //SceneManager.LoadScene(1);
        Debug.Log("defeated");

        SceneManager.MoveGameObjectToScene(FirstPersonController.instance.gameObject, SceneManager.GetActiveScene());
    }
}
