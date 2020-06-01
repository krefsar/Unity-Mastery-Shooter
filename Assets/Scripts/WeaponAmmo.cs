using System;
using UnityEngine;

public class WeaponAmmo : WeaponComponent
{
    public event Action OnAmmoChanged = delegate { };

    [SerializeField]
    private int maxAmmo = 24;
    [SerializeField]
    private int maxAmmoPerClip = 6;

    private int ammoInClip;
    private int ammoRemainingNotInClip;

    protected override void Awake()
    {
        ammoInClip = maxAmmoPerClip;
        ammoRemainingNotInClip = maxAmmo - ammoInClip;

        base.Awake();
    }

    public bool IsAmmoReady()
    {
        return ammoInClip > 0;
    }

    protected override void WeaponFired()
    {
        RemoveAmmo();
    }

    private void RemoveAmmo()
    {
        ammoInClip--;
        OnAmmoChanged();
    }

    public string GetAmmoText()
    {
        return string.Format("{0}/{1}", ammoInClip, ammoRemainingNotInClip);
    }
}