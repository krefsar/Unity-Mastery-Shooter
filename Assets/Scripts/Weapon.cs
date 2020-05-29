using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public KeyCode WeaponHotkey {  get { return weaponHotKey; } }
    public event Action OnFire = delegate { };

    [SerializeField]
    private readonly KeyCode weaponHotKey;
    [SerializeField]
    private float fireDelay = 0.25f;

    private float fireTimer;

    private void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (CanFire())
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        fireTimer = 0f;
        Debug.Log("Firing weapon " + gameObject.name);
        OnFire();
    }

    private bool CanFire()
    {
        return fireTimer >= fireDelay;
    }
}
