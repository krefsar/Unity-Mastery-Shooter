using UnityEngine;

[RequireComponent(typeof(Weapon))]
public abstract class WeaponComponent : MonoBehaviour
{
    protected Weapon weapon;

    protected abstract void WeaponFired();

    protected virtual void Awake()
    {
        weapon = GetComponent<Weapon>();
        weapon.OnFire += WeaponFired;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= WeaponFired;
    }
}
