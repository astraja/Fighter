using UnityEngine;

public class EnergyShield : Energy
{
    public override void Use()
    {
        int objectsCount = GetComponentsInChildren<Transform>().Length;
        if (objectsCount > 1) return;
        _energy -= _energyCost;
        UpdateEnergyUI();
        Instantiate(_energyPrefab,gameObject.transform);
    }
}
