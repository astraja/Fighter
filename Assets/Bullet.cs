using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * Time.deltaTime * 3);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable target = collision.gameObject.GetComponent<IDamagable>();
        //Hp hp = collision.gameObject.GetComponent<Hp>();
        if(target != null)
        {
            target.TakeDamage(2);
        }
        Destroy(gameObject);
    }

}
