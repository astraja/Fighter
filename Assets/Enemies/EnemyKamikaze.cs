using UnityEngine;

public class EnemyKamikaze : Enemy
{
    float timer = 0;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _aim;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _attackDelay)
        {
            Attack();
            timer = 0;
        }
    }

    public override void Attack()
    {
        Bullet bullet = Instantiate(_bullet, _aim.position, gameObject.transform.rotation).GetComponent<Bullet>();
        bullet.SetBullet(_power, _bulletSpeed);
    }
}
