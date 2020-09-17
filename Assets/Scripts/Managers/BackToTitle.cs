using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : SingletonBase<BackToTitle>
{
    [SerializeField]
    float momentToGoBack;
    float timer;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        timer = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void TimeToGoBack() 
    {
        if (!PlayerPosition.instance.gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (timer >= momentToGoBack)
            {
                timer = 0;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    protected override void BehaveSingleton()
    {
        TimeToGoBack();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
