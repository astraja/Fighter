using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int _power;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        //Hp target = collision.gameObject.GetComponent<Hp>();
        if (target != null)
        {
            target.TakeDamage(_power);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        //Hp target = collision.gameObject.GetComponent<Hp>();
        if (target != null)
        {
            target.TakeDamage(_power/2);
        }
    }
}
