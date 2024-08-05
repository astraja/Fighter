using UnityEngine;

public class DObstacle : MonoBehaviour, IDamagable
{
    public int Hp { get; protected set; }
    void Start()
    {
        Hp = 10;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        Debug.Log($"{Hp} hp left");
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
