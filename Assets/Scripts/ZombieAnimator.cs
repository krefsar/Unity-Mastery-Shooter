using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        GetComponent<Health>().OnTookHit += HandleTookHit;
        GetComponent<Health>().OnDied += HandleDied;
    }

    private void HandleDied()
    {
        animator.SetTrigger("Die");
    }

    private void HandleTookHit()
    {
        animator.SetTrigger("Hit");
    }
}
