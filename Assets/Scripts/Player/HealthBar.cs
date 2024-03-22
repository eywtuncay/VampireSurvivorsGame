using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] int maxHealth;
    int health;

    public static UnityAction OnPlayerDeath;

    private void OnEnable()
    {
        PlayerHealthManager.OnPlayerTakeDamage += TakeDamage;
    }
    private void OnDisable()
    {
        PlayerHealthManager.OnPlayerTakeDamage -= TakeDamage;
    }

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    void TakeDamage(float damageAmount)
    {
        if (health <= 0)
        {
            OnPlayerDeath?.Invoke();
        }

        health -= (int)damageAmount;
        health = Mathf.Max(0, health); 
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = health;
    }
}
