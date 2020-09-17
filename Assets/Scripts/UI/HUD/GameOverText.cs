using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : SingletonBase<GameOverText>
{
    GameObject gameOverText;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        gameOverText = GameObject.Find("/MainUI/TextCollection/GameOverText");
        gameOverText.SetActive(false);
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void ActivateGameOver() 
    {
        if (!PlayerPosition.instance.gameObject.activeInHierarchy) 
        {
            gameOverText.SetActive(true);
        }
    }

    protected override void BehaveSingleton()
    {
        ActivateGameOver();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
