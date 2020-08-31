using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour // PENDIENTE DE TESTEAR
{
    public List<GameObject> enemies;
    int enemiesDefeated;

    void DeactivateAll() 
    {
        for (int i = 0; i < enemies.Count; i++) 
        {
            enemies[i].SetActive(false);
        }
    }

    void Begin() 
    {
        DeactivateAll();
        enemiesDefeated = 0;
    }

    private void Start()
    {
        Begin();
    }

    public void ActivateEnemies() 
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(true);
        }
    }

    public bool CheckAllEnemiesDefeated() 
    {
        enemiesDefeated = 0;
        for (int i = 0; i < enemies.Count; i++) 
        {
            if (enemies[i].GetComponent<EnemyHealth>().GetHealth() <= 0) 
            {
                enemiesDefeated++;
            }
        }
        if (enemiesDefeated >= enemies.Count) 
        {
            return true;
        }
        return false;
    }
}
