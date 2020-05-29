using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponSound : WeaponComponent
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void WeaponFired()
    {
        audioSource.Play();
    }
}
