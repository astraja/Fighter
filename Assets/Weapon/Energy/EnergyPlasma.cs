using UnityEngine;

public class EnergyPlasma : Energy
{
    public override void Use()
    {
        Instantiate(_energyPrefab, gameObject.transform);
    }



}
