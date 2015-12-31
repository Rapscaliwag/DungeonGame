using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int initialHealth = 100;
    public int currentHealth;
    public Slider healthBar;

    void Awake ()
    {
        currentHealth = initialHealth;
    }

    public void TakeDamage (int damageTaken)
    {
        currentHealth -= damageTaken;
        healthBar.value = currentHealth; //yup
    }
}
