using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : SingletonBase<HealthUI>
{
    [SerializeField]
    Slider playerHealthSlider;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        playerHealthSlider.maxValue = PlayerHealth.instance.maxHealth;
        playerHealthSlider.value = PlayerHealth.instance.maxHealth;
    }

    private void Awake()
    {
        SingletonAwake();
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
