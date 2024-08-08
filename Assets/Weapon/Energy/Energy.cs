using System;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static event Action<int,int> EnergyChange;

    [SerializeField] protected GameObject _energyPrefab;
    [SerializeField] protected Transform _energyAim;
    [SerializeField] protected int _maxEnergy;
    [SerializeField] protected int _energyCost;
    [SerializeField] protected int _restoringPoints;
    protected int _energy;
    float _timer = 0f;

    void Start()
    {
        _energy = _maxEnergy;
        UpdateEnergyUI();
    }

    public virtual void Use()
    {
        
    }

    public void Add(int unit)
    {
        _energy = Math.Clamp(_energy + unit, _energy, _maxEnergy);
        UpdateEnergyUI();
    }



    protected void UpdateEnergyUI()
    {
        EnergyChange?.Invoke(_energy, _maxEnergy);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && _energy > _energyCost)
        {
            _energy -= _energyCost;
            UpdateEnergyUI();
            Use();
        }

        if(_energy < _maxEnergy)
        {
            _timer += Time.deltaTime;
            if (_timer > 1)
            {
                Add(_restoringPoints);
                _timer = 0f;
            }
        }
    }
}
