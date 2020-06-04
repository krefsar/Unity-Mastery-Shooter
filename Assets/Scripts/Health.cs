using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 1;

    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeHit(int amount)
    {
        currentHealth -= amount;
        GetComponentInChildren<Animator>().SetTrigger("Hit");
    }
}
