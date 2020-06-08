using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public bool IsFpsMode { get; set; }

    [SerializeField]
    private Transform firstPersonWeaponPoint;
    [SerializeField]
    private Transform thirdPersonWeaponPoint;

    private void Update()
    {
        if (IsFpsMode)
        {
            transform.position = firstPersonWeaponPoint.position;
            transform.rotation = firstPersonWeaponPoint.rotation;
        } else
        {
            transform.position = thirdPersonWeaponPoint.position;
            transform.rotation = thirdPersonWeaponPoint.rotation;
        }
    }
}
