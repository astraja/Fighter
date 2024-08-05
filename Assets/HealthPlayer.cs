using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour, IDamagable
{
    public static event Action<int> HealthChange;
    [SerializeField] int _maxHealth;
    int _health;
    void Start()
    {
        _health = _maxHealth;
        HealthChange?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChange?.Invoke(_health);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(int health)
    {
        _health = Math.Clamp(_health + health, _health, _maxHealth);
        HealthChange?.Invoke(_health);
    }
}
