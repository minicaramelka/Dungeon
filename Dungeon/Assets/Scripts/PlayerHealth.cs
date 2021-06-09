using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene("LoseMenu");
        }
    }

    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }
}
