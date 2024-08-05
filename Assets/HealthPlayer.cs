using System;
using UnityEngine;

public class HealthPlayer : Hp, IDamagable
{
    public static event Action<int> HealthChange;

    void Start()
    {
        _hp = _maxHp;
        HealthChange?.Invoke(_hp);
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        HealthChange?.Invoke(_hp);
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(int health)
    {
        _hp = Math.Clamp(_hp + health, _hp, _maxHp);
        HealthChange?.Invoke(_hp);
    }
}
