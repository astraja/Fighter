using UnityEngine;

public class AmmoPickUP : MonoBehaviour
{
    [SerializeField] int _quantity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Weapon target = collision.gameObject.GetComponentInChildren<Weapon>();
        if (target != null)
        {
            target.AddAmmo(_quantity);
            Destroy(gameObject);
        }

    }
}
