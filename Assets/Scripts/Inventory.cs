using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weapons;

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
    }
}
