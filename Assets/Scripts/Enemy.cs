using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Power { get; protected set; }
    public float AttackDelay { get; protected set; }
    public int BulletSpeed { get; protected set; }

    public virtual void Attack()
    {

    }

    public virtual void Move()
    {

    }
}
