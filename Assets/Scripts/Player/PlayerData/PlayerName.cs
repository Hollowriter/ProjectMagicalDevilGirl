using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerName : SingletonBase<PlayerName>
{
    [SerializeField]
    string playerName;

    private void Awake()
    {
        SingletonAwake();
    }

    public string GetPlayerName() 
    {
        return playerName;
    }
}
