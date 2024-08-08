using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    [SerializeField] GameObject weapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player target = collision.gameObject.GetComponent<Player>();

        if (target != null)
        {
            Transform weaponObject = target.gameObject.transform.Find("Weapon");
            Weapon[] weapons = weaponObject.GetComponentsInChildren<Weapon>();
            foreach (var w in weapons)
            {
                w.transform.gameObject.SetActive(false);
            }
            Instantiate(weapon, target.gameObject.transform.Find("Weapon"));
            
            Destroy(gameObject);
        }

    }
}
