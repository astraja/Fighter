using UnityEngine;

public class DoubleGun : Weapon
{
    [SerializeField] Transform[] _aims;

    public override void Attack()
    {
        _ammoQuantity-=2;
        UpdateAmmoUI();

        for(int i =0; i < _aims.Length; i++)
        {
            Bullet bullet = Instantiate(_bullet, _aims[i].position, gameObject.transform.rotation).GetComponent<Bullet>();
            bullet.SetBullet(_power, _bulletSpeed, _bulletColor);
        }
    }
}
