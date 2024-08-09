using System;
using UnityEngine;

public class HealthPlayer : Hp, IDamagable
{
    public static event Action<int> HealthChange;
    [SerializeField] protected GameObject _HpUIPrefab;
    new void Start()
    {
        base.Start();
        Instantiate(_HpUIPrefab);
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
