using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    private Health playerHealth;

    [SerializeField]
    private Image healthFillBar;
    [SerializeField]
    private TextMeshProUGUI healthText;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
        playerHealth.OnHealthChanged += HandleTookHit;
    }

    private void HandleTookHit(int currentHealth, int maxHealth)
    {
        healthText.text = string.Format("{0}/{1}", currentHealth, maxHealth);
        healthFillBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}
