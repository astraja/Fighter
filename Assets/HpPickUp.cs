using UnityEngine;

public class HpPickUp : MonoBehaviour
{
    [SerializeField] int _powerUp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthPlayer hp = collision.gameObject.GetComponent<HealthPlayer>();
        if (hp != null)
        {
            hp.AddHealth(_powerUp);
            Destroy(gameObject);
        }

    }
}