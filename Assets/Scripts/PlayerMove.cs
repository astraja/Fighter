using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] int _speed;

    void Start()
    {
    }


    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 xy = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * 0.8f, 0);
            transform.position += Time.deltaTime * _speed * xy;
           }
    }
}
