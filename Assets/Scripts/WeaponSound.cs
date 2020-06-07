using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponSound : WeaponComponent
{
    private AudioSource audioSource;

    [SerializeField]
    private SimpleAudioEvent audioEvent;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void WeaponFired()
    {
        audioEvent.Play(audioSource);
    }
}
