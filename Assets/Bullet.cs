using UnityEngine;

public class Bullet : MonoBehaviour
{
    int _power;
    int _speed;
    public void SetBullet(int power, int speed)
    {
        _power = power; 
        _speed = speed;
    }

    void Update()
    {
        //transform.position += (Vector3.left * Time.deltaTime * 3);
        //transform.position += (-transform.right * Time.deltaTime * 3);
        transform.Translate(Time.deltaTime * _speed * Vector3.left);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        //Hp target = collision.gameObject.GetComponent<Hp>();
        if(target != null)
        {
            target.TakeDamage(_power);
        }
        Destroy(gameObject);
    }

}
