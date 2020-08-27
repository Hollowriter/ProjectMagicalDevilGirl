using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : SingletonBase<HealthUI>
{
    [SerializeField]
    Slider playerHealthSlider;
    [SerializeField]
    Slider enemyHealthSlider;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        playerHealthSlider.maxValue = PlayerHealth.instance.maxHealth;
        playerHealthSlider.value = PlayerHealth.instance.maxHealth;
        enemyHealthSlider.maxValue = 1;
        enemyHealthSlider.value = 0;
    }

    private void Awake()
    {
        SingletonAwake();
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
