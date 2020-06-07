using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public bool Alive { get { return currentHealth > 0; } }

    public event Action OnTookHit = delegate { };
    public event Action OnDied = delegate { };
    public event Action<int, int> OnHealthChanged = delegate { };

    [SerializeField]
    private int maxHealth = 1;

    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        OnHealthChanged(currentHealth, maxHealth);
    }

    public void TakeHit(int amount)
    {
        if (Alive)
        {
            ModifyHealth(-amount);

            if (Alive)
            {
                OnTookHit();
            } else
            {
                OnDied();
            }
        }
    }
}
