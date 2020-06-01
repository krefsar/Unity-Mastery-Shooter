using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public KeyCode WeaponHotkey {  get { return weaponHotKey; } }
    public bool IsInAimMode {  get { return !Input.GetMouseButton(1); } }

    public event Action OnFire = delegate { };

    [SerializeField]
    private KeyCode weaponHotKey;
    [SerializeField]
    private float fireDelay = 0.25f;

    private float fireTimer;
    private WeaponAmmo ammo;

    private void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
    }

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
        OnFire();
    }

    private bool CanFire()
    {
        if (ammo != null && !ammo.IsAmmoReady())
        {
            return false;
        }

        return fireTimer >= fireDelay;
    }
}
