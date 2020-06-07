using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIAmmoText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;
    private WeaponAmmo currentWeaponAmmo;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
        Inventory.OnWeaponChanged += HandleWeaponChanged;
    }

    private void HandleWeaponChanged(Weapon weapon)
    {
        if (currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged -= HandleAmmoChanged;
        }

        currentWeaponAmmo = weapon.GetComponent<WeaponAmmo>();

        if (currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChanged += HandleAmmoChanged;
            tmproText.text = currentWeaponAmmo.GetAmmoText();
        } else
        {
            tmproText.text = "Unlimited";
        }
    }

    private void HandleAmmoChanged()
    {
        tmproText.text = currentWeaponAmmo.GetAmmoText();
    }
}
