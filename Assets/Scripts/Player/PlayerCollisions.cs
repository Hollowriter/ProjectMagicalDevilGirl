using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : SingletonBase<PlayerCollisions>
{
    bool grounded;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        grounded = false;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public bool GetGrounded() 
    {
        return grounded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            grounded = false;
        }
    }
}
