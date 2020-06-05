using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public event Action OnAttack = delegate { };

    [SerializeField]
    [Tooltip("How long the zombie waits after an attack to attack again")]
    private float delayBetweenAttacks = 1.5f;
    [SerializeField]
    private float delayBetweenAnimationAndDamage = 0.5f;
    [SerializeField]
    [Tooltip("How far away the zombie can attack from")]
    private float maximumAttackRange = 1.5f;
    [SerializeField]
    private int damage = 1;

    private Health playerHealth;
    private float attackTimer;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (CanAttack())
        {
            attackTimer = 0;
            Attack();
        }
    }

    private void Attack()
    {
        OnAttack();
        StartCoroutine(DealDamageAfterDelay());
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        playerHealth.TakeHit(damage);
    }

    private bool CanAttack()
    {
        return attackTimer >= delayBetweenAttacks &&
            Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumAttackRange;
    }
}
