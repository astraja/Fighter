using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Power { get; protected set; }
    public int Hp { get; protected set; }

    public virtual void Attack()
    {
       //Debug.Log($"Shoot!");

    }
}
