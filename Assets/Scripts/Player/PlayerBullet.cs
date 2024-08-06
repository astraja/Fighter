using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    int _power;
    int _speed;

    public void SetBullet(int power, int speed, Color color)
    {
        _power = power;
        _speed = speed;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * _speed * Vector3.right);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        Hp target = collision.gameObject.GetComponent<Hp>();
        if (target != null)
        {
            target.TakeDamage(_power);
        }
        Destroy(gameObject);
    }

}
