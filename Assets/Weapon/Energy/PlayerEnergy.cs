using System;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public static event Action<int> EnergyChange;

    [SerializeField] int _maxEnergy;
    int _energyCost = 2;
    int _energy;

    void Start()
    {
        _energy = _maxEnergy;
        UpdateEnergyUI();
    }

    public void UseEnergy(int unit)
    {
        _energy -= unit;
        UpdateEnergyUI();
    }

    public void Add(int unit)
    {
        _energy = Math.Clamp(_energy + unit, _energy, _maxEnergy);
        UpdateEnergyUI();
    }

    void UpdateEnergyUI()
    {
        EnergyChange?.Invoke(_energy);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            UseEnergy(1);
        }

    }
}
