using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;

    void Start()
    {
        player.GetComponent<SpriteRenderer>().color = player.PlayerColor;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            player.Attack();
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 xy = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            player.Move(Time.deltaTime*player.MaxSpeed*xy);
        }
    }
}
