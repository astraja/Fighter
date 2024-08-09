using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    [SerializeField] Slider _bar;

    private void Start()
    {

    }

    private void OnEnable()
    {
        Energy.EnergyChange += OnChange;
    }

    private void OnDisable()
    {
        Energy.EnergyChange -= OnChange;
    }

    void OnChange(int energy, int maxVal)
    {
           _bar.value = (float)energy / maxVal;
    }

}
