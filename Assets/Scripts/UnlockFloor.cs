using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnlockFloor : MonoBehaviour
{
    [SerializeField] private GameObject floorToUnlock;
    [SerializeField] private ParticleSystem unlockParticleSystem;

    // private bool unlockInput;

    private void Update()
    {
       bool unlockInput = Input.GetKeyDown(KeyCode.Space);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si entramos en el trigger y todavía no hemos desbloqueado el suelo, mostramos el panel
        if (other.gameObject.CompareTag("Player") && !floorToUnlock.activeInHierarchy)
        {
            UIManager.sharedInstance.ShowPressEKeyPanel();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Si el Player entra está en el trigger, el suelo no está desbloqueado y pulsamos E,
        // desbloqueamos el suelo, ocultamos el panel y paramos el sistema de partículas
        if (other.gameObject.CompareTag("Player") && !floorToUnlock.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            floorToUnlock.SetActive(true);
            UIManager.sharedInstance.HidePressEKeyPanel();
            unlockParticleSystem.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si salimos del el trigger, ocultamos el panel
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.sharedInstance.HidePressEKeyPanel();
        }
    }
}
