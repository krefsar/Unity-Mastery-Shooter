using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static event Action<Weapon> OnWeaponChanged = delegate { };

    [SerializeField]
    private Weapon[] weapons;

    private void Awake()
    {
        SwitchToWeapon(weapons[0]);
    }

    private void Update()
    {
        foreach (var weapon in weapons)
        {
            if (Input.GetKeyDown(weapon.WeaponHotkey))
            {
                SwitchToWeapon(weapon);
                break;
            }
        }
    }

    private void SwitchToWeapon(Weapon weaponToUse)
    {
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(weapon == weaponToUse);
        }

        OnWeaponChanged(weaponToUse);
    }
}
