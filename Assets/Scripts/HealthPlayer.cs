using System;
using UnityEngine;

public class HealthPlayer : Hp
{
    public static event Action<int> HealthChange;

    new void Start()
    {
        base.Start();
        UpdateHpUI();
    }


    public override void TakeDamage(int damage)
    {
        _hp = UpdateHp(damage);
        UpdateHpUI();
        Die();
    }

    public void AddHealth(int health)
    {
        _hp = Math.Clamp(_hp + health, _hp, _maxHp);
        UpdateHpUI();
    }

    void UpdateHpUI()
    {
        HealthChange?.Invoke(_hp);
    }
}
