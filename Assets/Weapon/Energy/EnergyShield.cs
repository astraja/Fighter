using UnityEngine;

public class EnergyShield : Energy
{
    public override void Use()
    {
        Instantiate(_energyPrefab,gameObject.transform);
        Debug.Log("ise");
    }
}
