using UnityEngine;

public  class Player : MonoBehaviour
{
   
    public string Name {  get; protected set; }
    public Color PlayerColor { get; protected set; }


    [SerializeField] string _name;
    [SerializeField] Color _color;


    public void Start()
    {
        Name = _name;
        PlayerColor = _color;

        gameObject.GetComponent<SpriteRenderer>().color = _color;
    }


}
