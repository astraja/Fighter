using UnityEngine;

public class Plasma : MonoBehaviour
{
    [SerializeField] int _power;
    [SerializeField] Sprite _sprite;
    float _timer = 0;
    Energy _energy;

    void Start()
    {
        _energy = GetComponentInParent<Energy>();
    }

    private void Update()
    {
        UseEnergy();
    }
    void UseEnergy()
    {
        _timer += Time.deltaTime;
        if (_timer > 1)
        {
            if(_energy != null && _energy._energyCost > _energy._energy) Destroy(gameObject);
            _energy.Take(_energy._energyCost);
            
            _timer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        if (target != null)
        {
            target.TakeDamage(_power);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        if (target != null)
        {
            target.TakeDamage(_power / 2);
        }
    }
}
