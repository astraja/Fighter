using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public static EnergyUI Instance { get; private set; }
    [SerializeField] Slider _bar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
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
