using System;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private GameObject currentObject;
    [SerializeField] private GameObject hudInteractText;
    [SerializeField] private AudioSource aud;
    private Vector3 cubeStartPos;
    private Quaternion cubeStartRot;

    private void Awake()
    {
        cubeStartPos = transform.localPosition;
        cubeStartRot = transform.localRotation;
    }

    
    private void OnTriggerEnter(Collider other) //Ring entered our interaction area.
    {
        if (other.CompareTag("Ring"))
        {
            currentObject = other.gameObject;
            hudInteractText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) //Ring exited our interaction area.
    {
        if (other.CompareTag("Ring"))
        {
            currentObject = null;
            hudInteractText.SetActive(false);
        }
    }

    private void Update() 
    {
        transform.localRotation = cubeStartRot; //Portals mess up transform, set it back every update.
        transform.localPosition = cubeStartPos;
        if (Input.GetKeyDown(KeyCode.E) && currentObject) //Collect coin.
        {
            currentObject.SetActive(false);
            currentObject = null;
            hudInteractText.SetActive(false);
            aud.Play();
        }
    }
}
