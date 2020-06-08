using System;
using System.Collections;
using UnityEngine;

public class WeaponAmmo : WeaponComponent
{
    public event Action OnAmmoChanged = delegate { };

    [SerializeField]
    private bool infiniteAmmo = false;
    [SerializeField]
    private int maxAmmo = 24;
    [SerializeField]
    private int maxAmmoPerClip = 6;
    [SerializeField]
    private float reloadTime = 0.2f;

    private int ammoInClip;
    private int ammoRemainingNotInClip;

    protected override void Awake()
    {
        ammoInClip = maxAmmoPerClip;
        ammoRemainingNotInClip = maxAmmo - ammoInClip;

        base.Awake();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
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

    private IEnumerator Reload()
    {
        int ammoMissingFromClip = maxAmmoPerClip - ammoInClip;

        int ammoToMove = Mathf.Min(ammoMissingFromClip, ammoRemainingNotInClip);
        if (infiniteAmmo)
        {
            ammoToMove = ammoMissingFromClip;
        }

        while (ammoToMove > 0)
        {
            yield return new WaitForSeconds(reloadTime);

            ammoInClip++;
            ammoRemainingNotInClip--;
            OnAmmoChanged();
            ammoToMove--;
        }
    }

    public string GetAmmoText()
    {
        if (infiniteAmmo)
        {
            return string.Format("{0}/∞", ammoInClip, ammoRemainingNotInClip);
        }
        else
        {
            return string.Format("{0}/{1}", ammoInClip, ammoRemainingNotInClip);
        }

    }
}