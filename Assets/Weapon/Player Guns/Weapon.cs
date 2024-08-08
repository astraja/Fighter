using System;
using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected Transform _aim;
    [SerializeField] protected int _power;
    [SerializeField] protected int _ammoQuantity;
    [SerializeField] protected int _bulletSpeed;
    [SerializeField] protected Color _bulletColor;
    [SerializeField] float _shootDelay;
    [SerializeField] AudioClip _attackSound;
    AudioSource _audios;
    float _lastShot = 0;

    public static event Action<int> AmmoChange;

    void Start()
    {
        UpdateAmmoUI();
        _audios = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    private void OnEnable()
    {
        UpdateAmmoUI();
    }

    void Update()
    {
        _lastShot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && _lastShot >= _shootDelay && _ammoQuantity > 0)
        {
            Attack();
            _lastShot = 0;
            if (_audios != null) _audios.PlayOneShot(_attackSound, 0.3F);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    public virtual void Attack()
    {
        _ammoQuantity--;
        UpdateAmmoUI();
        Bullet bullet = Instantiate(_bullet, _aim.position, gameObject.transform.rotation).GetComponent<Bullet>();
        bullet.SetBullet(_power, _bulletSpeed, _bulletColor);
    }

    protected void UpdateAmmoUI()
    {
        AmmoChange?.Invoke(_ammoQuantity);
    }
    public void AddAmmo(int ammo)
    {
        _ammoQuantity += ammo;
        UpdateAmmoUI();
    }

    void SwitchWeapon()
    {
        
        Transform p = transform.parent.transform;
        int weaponsCount = p.childCount;
        if (weaponsCount == 1) return;
        int index = gameObject.transform.GetSiblingIndex();

        if (index < weaponsCount - 1)
        {
            p.GetChild(index+1).gameObject.SetActive(true);    
            gameObject.SetActive(false);
        }
        else
        {
            p.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
}
