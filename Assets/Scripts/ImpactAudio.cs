using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Health))]
public class ImpactAudio : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private SimpleAudioEvent audioEvent;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GetComponent<Health>().OnTookHit += HandleTookHit;
    }

    private void HandleTookHit()
    {
        audioEvent.Play(audioSource);
    }
}
