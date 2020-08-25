using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    int health;

    void Begin() 
    {
        health = maxHealth;
    }

    private void Awake()
    {
        Begin();
    }

    public void SetHealth(int _health)
    {
        health = _health;
    }

    public int GetHealth()
    {
        return health;
    }
}
