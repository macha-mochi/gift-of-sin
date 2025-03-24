using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sins : MonoBehaviour
{
    [SerializeField] GameObject artifact;

    public void Deactivate() //to be called by fungus
    {
        gameObject.SetActive(false);
    }
    public void DropArtifact() //to be called by fungus
    {
        artifact.SetActive(true);
        artifact.transform.parent = null;
    }
}
