using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<EnemyThrow>() != null) 
            {
                collision.gameObject.GetComponent<EnemyThrow>().SetAttackTimer(0);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
