using UnityEngine;

public class AmmoPickUP : MonoBehaviour
{
    [SerializeField] int _quantity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerShooting target = collision.gameObject.GetComponent<PlayerShooting>();
        if (target != null)
        {
            target.AddAmmo(_quantity);
            Destroy(gameObject);
        }

    }
}
