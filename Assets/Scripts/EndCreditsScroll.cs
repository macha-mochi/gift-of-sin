using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndCreditsScroll : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Button b;
    [SerializeField] TextMeshProUGUI cockroachText;

    private RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        int numLeft = FirstPersonController.instance.numCockroachesLeft;
        cockroachText.text = numLeft + "/9 cockroaches remain.";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*Debug.Log(Screen.width);
        if(rt.position.y < (750/690.0f) * Screen.width)
        {
            rt.position = rt.position + new Vector3(0, speed, 0);
        }
        else
        {
            if (!b.interactable) b.interactable = true;
        }*/
    }
    public void goToMainMenu() //to be called by button
    {
        //restart stuff: dash, breakable, pride, envy
        Debug.Log("main menu");
        SceneManager.MoveGameObjectToScene(FirstPersonController.instance.gameObject, SceneManager.GetActiveScene());
        Breakable.broken = false;
        Pride.talkedTo = false;
        Envy.talkedTo = false;
        Wrath.talkedTo = false;
        SceneManager.LoadScene(0);
    }
}
//631
//1346 
