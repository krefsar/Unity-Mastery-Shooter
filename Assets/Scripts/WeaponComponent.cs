using UnityEngine;

[RequireComponent(typeof(Weapon))]
public abstract class WeaponComponent : MonoBehaviour
{
    private Weapon weapon;

    protected abstract void WeaponFired();

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        weapon.OnFire += WeaponFired;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= WeaponFired;
    }
}
