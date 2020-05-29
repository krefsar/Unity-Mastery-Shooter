using UnityEngine;

public class WeaponParticle : WeaponComponent
{
    [SerializeField]
    private ParticleSystem muzzleFlash;

    protected override void WeaponFired()
    {
        muzzleFlash.Play();
    }
}
