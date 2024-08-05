using UnityEngine;

public class Hp : MonoBehaviour, IDamagable
{

    [SerializeField] int _health;
    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"Health: {_health}");
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
