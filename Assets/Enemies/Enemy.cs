using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int _power;
    [SerializeField] protected float _attackDelay;
    [SerializeField] protected int _bulletSpeed;

    public virtual void Attack()
    {

    }

    public virtual void Move()
    {

    }
}
