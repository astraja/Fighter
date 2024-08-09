using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public static HealthUI Instance { get; private set; }
    [SerializeField] Image _healthImg;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

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
