using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeToBlackText : MonoBehaviour
{
    [TextArea] public List<string> lines = new List<string>();
    [SerializeField] Image backgroundPanel;
    [SerializeField] TextMeshProUGUI text;

    private bool showText = false;
    private float t;
    private int index = 0;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool textAnimating = false;
    private List<Coroutine> coroutines = new List<Coroutine>();
    private FirstPersonController player;

    public bool cockroachBoss;

    private void Start()
    {
        player = FirstPersonController.instance;
    }

    private void OnEnable()
    {
        t = 0;
        index = 0;
        showText = false;
        fadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            t += Time.deltaTime * 2.5f;
            backgroundPanel.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), t);
            if(t >= 1f)
            {
                fadeIn = false;
                t = 0;
            }
        }else if (fadeOut)
        {
            t += Time.deltaTime * 2.5f;
            backgroundPanel.color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), t);
            if (t >= 1f)
            {
                fadeOut = false;
                t = 0;
                gameObject.SetActive(false);
                player.DeactivateCutsceneMode();

                //SPAGHETTI ALERT
                if (cockroachBoss)
                {
                    SceneManager.LoadScene(1);
                }

            }
        } else {
            if (!showText)
            {
                //first frame after faded in
                index = 0;
                showText = true;
                coroutines.Add(StartCoroutine(ShowText()));
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //left click
                    if (textAnimating)
                    {
                        foreach(Coroutine c in coroutines)
                        {
                            StopCoroutine(c);
                        }
                        coroutines.Clear();
                        textAnimating = false;
                        text.SetText(lines[index]);
                    }
                    else
                    {
                        index++;
                        if (index == lines.Count)
                        {
                            text.SetText("");
                            fadeOut = true;
                        }
                        else
                        {
                            text.SetText("");
                            coroutines.Add(StartCoroutine(ShowText()));
                        }
                    }
                }
            }
        }
    }

    IEnumerator ShowText()
    {
        textAnimating = true;
        char[] chars = lines[index].ToCharArray();
        for(int i = 0; i < chars.Length; i++)
        {
            text.SetText(text.text + chars[i]);
            yield return new WaitForSeconds(0.05f);
        }
        textAnimating = false;
    }

}
