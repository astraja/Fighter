using UnityEngine;

public  class Player : MonoBehaviour
{
   
    public int MaxPower {  get; protected set; }
    public int MaxSpeed { get; protected set; }
    // int MaxAmmo { get; private set; }
    
    public Color PlayerColor { get; protected set; }
    public int Ammo {  get; protected set; }

    public void Attack()
    {
        if (Ammo > 0)
        {
            Ammo--;
            Debug.Log($"Shoot! {Ammo} ammo left");
        }
        else
        {
            Debug.Log("No ammo");
        }
    }

    public void Move(Vector3 dis)
    {
        transform.position += dis;
    }

}
