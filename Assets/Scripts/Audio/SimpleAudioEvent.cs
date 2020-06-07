using UnityEngine;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : ScriptableObject
{
    [SerializeField]
    private AudioClip[] clips = new AudioClip[0];
    [SerializeField]
    private RangedFloat volume = new RangedFloat(1, 1);
    [SerializeField]
    [MinMaxRange(0f, 2f)]
    private RangedFloat pitch = new RangedFloat(1, 1);

    public void Play(AudioSource source)
    {
        int clipIndex = Random.Range(0, clips.Length);
        source.clip = clips[clipIndex];
        source.Play();
    }
}
