using UnityEngine;

public class Bullet : MonoBehaviour
{
    int _power;
    int _speed;
    Vector3 _dir;

    private void Start()
    {
        Destroy(gameObject, 2);
    }

    public void SetBullet(int power, int speed)
    {
        _power = power; 
        _speed = speed;
        _dir = Vector3.left;
    }

    public void SetBullet(int power, int speed, Color color)
    {
        _power = power;
        _speed = speed;
        _dir = Vector3.right;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    void Update()
    {
        //transform.position += (-transform.right * Time.deltaTime * 3);
        transform.Translate(Time.deltaTime * _speed * _dir);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        Hp target = collision.gameObject.GetComponent<Hp>();
        if(target != null)
        {
            target.TakeDamage(_power);
        }
        Destroy(gameObject);
    }

}
