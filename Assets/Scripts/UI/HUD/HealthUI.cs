using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : SingletonBase<HealthUI>
{
    [SerializeField]
    Text playerName;
    [SerializeField]
    Slider playerHealthSlider;
    [SerializeField]
    Text enemyName;
    [SerializeField]
    Slider enemyHealthSlider;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        playerName.text = PlayerName.instance.GetPlayerName();
        playerHealthSlider.maxValue = PlayerHealth.instance.maxHealth;
        playerHealthSlider.value = PlayerHealth.instance.maxHealth;
        enemyName.text = " ";
        enemyHealthSlider.maxValue = 1;
        enemyHealthSlider.value = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetEnemyName(string _text) 
    {
        enemyName.text = _text;
    }

    public void SetEnemyHealthSlider(float _maxValue, float _value) 
    {
        enemyHealthSlider.maxValue = _maxValue;
        enemyHealthSlider.value = _value;
    }

    protected override void BehaveSingleton()
    {
        playerHealthSlider.value = PlayerHealth.instance.GetHealth();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
