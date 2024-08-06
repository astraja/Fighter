using System;
using UnityEngine;

public class HealthPlayer : Hp
{
    public static event Action<int> HealthChange;

    void Start()
    {
        _hp = _maxHp;
        Debug.Log("HP Player");
        HealthChange?.Invoke(_hp);
    }

    public override void TakeDamage(int damage)
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
