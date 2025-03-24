using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupInRange : MonoBehaviour
{
    [SerializeField] [TextArea] string popupText;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            FirstPersonController.instance.ActivatePopup();
            FirstPersonController.instance.SetPopupText(popupText);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            FirstPersonController.instance.DeactivatePopup();
        }
    }
}
