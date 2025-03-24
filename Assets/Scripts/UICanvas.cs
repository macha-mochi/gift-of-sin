using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Canvas))]
public class UICanvas : MonoBehaviour
{
    public static UICanvas instance;
    [SerializeField] List<GameObject> preserveActiveStatusWhenEnable;
    public List<bool> activeStatus = new List<bool>();
    [SerializeField] Image damageScreen;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void DisableUI() {
        activeStatus.Clear();
        foreach (GameObject obj in preserveActiveStatusWhenEnable)
        {
            activeStatus.Add(obj.activeInHierarchy);
        }
        for (int i =0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void EnableUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        for(int i = 0; i < preserveActiveStatusWhenEnable.Count; i++)
        {
            preserveActiveStatusWhenEnable[i].SetActive(activeStatus[i]);
        }
    }
    public void clearDamageScreen()
    {
        damageScreen.color = new Color(255, 0, 0, 0);
    }
}
