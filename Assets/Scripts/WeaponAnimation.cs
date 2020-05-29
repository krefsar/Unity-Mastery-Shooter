using UnityEngine;

[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Animator))]
public class WeaponAnimation : MonoBehaviour
{
    private Weapon weapon;
    private Animator animator;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        weapon.OnFire += HandleWeaponFire;
    }

    private void OnDestroy()
    {
        weapon.OnFire -= HandleWeaponFire;
    }

    private void HandleWeaponFire()
    {
        animator.SetTrigger("Fire");
    }
}
