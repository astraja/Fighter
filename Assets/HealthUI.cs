using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Image _healthImg;

    private void OnEnable()
    {
        HealthPlayer.HealthChange += OnHealthChange;
    }

    private void OnDisable()
    {
        HealthPlayer.HealthChange -= OnHealthChange;
    }

    void OnHealthChange(int health)
    {
        _healthImg.fillAmount = health / 10.0f;
    }
}
