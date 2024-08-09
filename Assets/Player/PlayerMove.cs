using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] int _speed;
    Vector3 _dir;

    void Update()
    {
        _dir = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        _dir.y *= 0.8f;
        transform.Translate(Time.deltaTime * _speed * _dir);
    }
}
