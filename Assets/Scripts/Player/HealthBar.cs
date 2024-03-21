using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider healthBar;
    [SerializeField] int maxHealth;
    int health;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddHealth(10);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddHealth(-10);
        }
    }

    void AddHealth (int value)
    {
        health += value;
        if (health>maxHealth)
        {
            health = maxHealth;
        }
        else if (health<0)
        {
            health = 0;
        }
        healthBar.value = health;
    }


}
