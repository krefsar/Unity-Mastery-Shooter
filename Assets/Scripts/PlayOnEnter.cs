using UnityEngine;
using UnityEngine.Playables;

public class PlayOnEnter : MonoBehaviour
{
    private PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null)
        {
            director.Play();
        }
    }
}
