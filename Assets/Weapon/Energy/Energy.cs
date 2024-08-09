using System;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public static event Action<int,int> EnergyChange;
    [SerializeField] protected GameObject _energyUIPrefab;
    [SerializeField] protected GameObject _energyPrefab;
    [SerializeField] protected Transform _energyAim;
    [SerializeField] protected int _maxEnergy;
    [SerializeField] public int _energyCost;
    [SerializeField] protected int _restoringPoints;
    public int _energy;
    float _timer = 0f;

    void Start()
    {
        _energy = _maxEnergy;
        Instantiate(_energyUIPrefab);
        UpdateEnergyUI();
    }

    public virtual void Use()
    {
        //Create energy object (shield, attack, etc.)
    }

    public void Add(int unit)
    {
        _energy = Math.Clamp(_energy + unit, _energy, _maxEnergy);
        UpdateEnergyUI();
    }
    public void Take(int unit)
    {
        if (_energy > 0)
        {
            _energy -= unit;
            UpdateEnergyUI();
        }
    }

    protected void UpdateEnergyUI()
    {
        EnergyChange?.Invoke(_energy, _maxEnergy);
    }

    void RestoreEnergy()
    {
        if (_energy < _maxEnergy)
        {
            _timer += Time.deltaTime;
            if (_timer > 1)
            {
                Add(_restoringPoints);
                _timer = 0f;
            }
        }
    }

    private void Update()
    {
        RestoreEnergy();
        if (_energy > _energyCost && Input.GetButtonDown("Fire2"))
        {

            Use();
        }
    }
}
