using UnityEngine;

public class Hp : MonoBehaviour, IDamagable
{
    [SerializeField] protected int _maxHp;
    protected int _hp;

    void Start()
    {
        _hp = _maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
