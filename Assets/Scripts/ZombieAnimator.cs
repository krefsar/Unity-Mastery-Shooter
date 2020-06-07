using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animator;
    private ZombieAttack zombieAttack;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        GetComponent<Health>().OnTookHit += HandleTookHit;
        GetComponent<Health>().OnDied += HandleDied;

        GetComponent<ZombieAttack>().OnAttack += HandleAttack;
    }

    private void HandleAttack()
    {
        int attackId = Random.Range(1, 3);
        animator.SetInteger("AttackId", attackId);
        animator.SetTrigger("Attack");
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
