
using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _aim;
    [SerializeField] int _power;
    [SerializeField] int _ammo;
    [SerializeField] int _bulletSpeed;
    Player player;

    public static event Action<int> AmmoChange;
    public void Awake()
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
        UpdateAmmoUI();
    }

    public void Attack()
    {
        if (_ammo > 0)
        {
            _ammo--;
            UpdateAmmoUI();
            Bullet bullet = Instantiate(_bullet, _aim.position, gameObject.transform.rotation).GetComponent<Bullet>();
            bullet.SetBullet(_power, _bulletSpeed, player.PlayerColor);
        }
    }

    public void AddAmmo(int ammo)
    {
        _ammo += ammo;
        UpdateAmmoUI();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void UpdateAmmoUI()
    {
        AmmoChange?.Invoke(_ammo);
    }
}
