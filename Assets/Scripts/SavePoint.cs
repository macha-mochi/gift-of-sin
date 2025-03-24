using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] GameObject vn;
    private bool interacting = false;
    [SerializeField] private Transform trans;
    private void Update()
    {
        if (interacting)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                vn.SetActive(true);
            }
        }
    }
    public void Exit()
    {
        vn.SetActive(false);
    }
    public void Savepoint() {
        Health.instance.savePoint = trans.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interacting = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interacting = false;
        }
    }
    public void ActivateCutsceneMode()
    {
        FirstPersonController.instance.CutsceneMode();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void DeactivateCutsceneMode()
    {
        FirstPersonController.instance.DeactivateCutsceneMode();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
