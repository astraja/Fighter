using UnityEngine;

public class Gun : Weapon
{
    public override void Attack()
    {
        _ammoQuantity--;
        UpdateAmmoUI();
        Bullet bullet = Instantiate(_bullet, _aim.position, gameObject.transform.rotation).GetComponent<Bullet>();
        bullet.SetBullet(_power, _bulletSpeed, _bulletColor);
        bullet.gameObject.transform.localScale += Vector3.one;
    }
}

