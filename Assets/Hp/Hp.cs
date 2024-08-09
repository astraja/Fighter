using UnityEngine;

public class Hp : MonoBehaviour, IDamagable
{
    [SerializeField] protected GameObject _deathEffect;
    [SerializeField] protected int _maxHp;
    protected int _hp;

    protected void Start()
    {
        _hp = _maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        _hp = UpdateHp(damage);
        Die();
    }

    protected int UpdateHp(int damage)
    {
        return _hp - damage;
    }

    protected void Die()
    {
        if (_hp <= 0)
        {
            ShowDeathEffect();
            Destroy(gameObject);
        }
    }

    void ShowDeathEffect()
    {
        if (_deathEffect != null)
        {
            GameObject dEffect = Instantiate(_deathEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(dEffect, 1);
        }
    }

}
