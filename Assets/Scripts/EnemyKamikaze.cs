using UnityEngine;

public class EnemyKamikaze : Enemy
{
    float timer = 0;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _aim;
    public EnemyKamikaze()
    {
        Power = 5;
        AttackDelay = 1f;
        BulletSpeed = 10;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= AttackDelay)
        {
            Attack();
            timer = 0;
        }
    }

    public override void Attack()
    {
        Bullet bullet = Instantiate(_bullet, _aim.position, gameObject.transform.rotation).GetComponent<Bullet>();
        bullet.SetBullet(Power, BulletSpeed);
    }
}
