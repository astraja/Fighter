using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] Image _barImg;

    private void OnEnable()
    {
        PlayerEnergy.EnergyChange += OnChange;
    }

    private void OnDisable()
    {
        PlayerEnergy.EnergyChange -= OnChange;
    }

    void OnChange(int unit)
    {
        _barImg.fillAmount = unit / 10.0f;
    }
}
