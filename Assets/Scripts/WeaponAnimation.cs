using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimation : WeaponComponent
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected override void WeaponFired()
    {
        animator.SetTrigger("Fire");
    }
}
