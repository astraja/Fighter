using UnityEngine;

public class EnemyKamikaze : Enemy
{
    float timer = 0;
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform aim;
    public EnemyKamikaze(){

        Power = 10;
        Hp = 10;

    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Attack();
            timer = 0;
        }
    }

    public override void Attack()
    {
        GameObject bullet = Instantiate(_bullet, aim.position, Quaternion.identity);
    }
}
