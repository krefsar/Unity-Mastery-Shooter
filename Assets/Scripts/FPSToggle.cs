using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject[] firstPersonObjects;
    [SerializeField]
    private GameObject[] thirdPersonObjects;
    [SerializeField]
    private KeyCode toggleKey = KeyCode.F1;

    private bool isFpsMode;

    private void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        isFpsMode = !isFpsMode;

        ToggleObjectsForCurrentMode();
    }

    private void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObj in firstPersonObjects)
        {
            gameObj.SetActive(isFpsMode);
        }

        foreach (var gameObj in thirdPersonObjects)
        {
            gameObj.SetActive(!isFpsMode);
        }
    }
}
