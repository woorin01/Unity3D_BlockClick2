using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public MeshRenderer MeshRenderer
    {
        get
        {
            return meshRenderer;
        }
        set
        {
            meshRenderer = value;
        }
    }

    private bool inPlayer;
    public bool InPlayer
    {
        get
        {
            return inPlayer;
        }
        set
        {
            inPlayer = value;
        }
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("응기잇");
            inPlayer = true;
            meshRenderer.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("하읏");
            inPlayer = false;
            meshRenderer.enabled = true;
        }
    }
}
