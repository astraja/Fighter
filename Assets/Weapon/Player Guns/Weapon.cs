using System;
using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static event Action<int> AmmoChange;
    [SerializeField] protected GameObject ammoUIPrefab;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform[] aims;
    [SerializeField] protected int power;
    [SerializeField] protected int ammoQuantity;
    [SerializeField] protected int bulletSpeed;
    [SerializeField] protected Vector3 bulletSize;
    [SerializeField] protected Color bulletColor;
    [SerializeField] float _shootDelay;
    [SerializeField] AudioClip _attackSound;
    AudioSource _audios;
    float _lastShot = 0;

    void Start()
    {
        Instantiate(ammoUIPrefab);
        _audios = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }

    private void OnEnable()
    {
        UpdateAmmoUI();
    }

    void Update()
    {
        _lastShot += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && _lastShot >= _shootDelay && ammoQuantity > 0)
        {
            Attack(Vector3.one, 1);
            _lastShot = 0;
            if (_audios != null) _audios.PlayOneShot(_attackSound, 0.3F);
        }

        if (Input.GetButtonDown("Jump"))
        {
            SwitchWeapon();
        }
    }

    public virtual void Attack(Vector3 size, int ammo)
    {
        TakeAmmo(ammo);
        InstantiateBullet();
    }

    protected void InstantiateBullet()
    {
        for (int i = 0; i < aims.Length; i++)
        {
            Bullet xbullet = Instantiate(bullet, aims[i].position, gameObject.transform.rotation).GetComponent<Bullet>();
            xbullet.SetBullet(power, bulletSpeed, bulletColor);
            xbullet.gameObject.transform.localScale = bulletSize;
        }
    }

    void SwitchWeapon()
    {
        Transform p = transform.parent.transform;
        int weaponsCount = p.childCount;
        if (weaponsCount == 1) return;
        int index = gameObject.transform.GetSiblingIndex();

        if (index < weaponsCount - 1)
        {
            p.GetChild(index + 1).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            p.GetChild(0).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void AddAmmo(int ammo)
    {
        ammoQuantity += ammo;
        UpdateAmmoUI();
    }

    protected void TakeAmmo(int ammo)
    {
        ammoQuantity -= ammo;
        UpdateAmmoUI();
    }

    protected void UpdateAmmoUI()
    {
        AmmoChange?.Invoke(ammoQuantity);
    }
}
