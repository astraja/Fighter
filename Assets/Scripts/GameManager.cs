using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(player);
        }
    }
}
