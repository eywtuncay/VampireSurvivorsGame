using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{

    [SerializeField] Slider healtBar;
    [SerializeField] int maxHealth;
    int health;


    void Start()
    {
        health = maxHealth;
        healtBar.maxValue = maxHealth;
        healtBar.value = health;
    }


    void Update()
    {
        //testing
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddHealth(10);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AddHealth(-10);
        }

    }


    void AddHealth(int value) // ya da add helath olabilir
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }

        healtBar.value = health;
    }


}
