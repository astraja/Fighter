using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] Image _ammoImg;
    [SerializeField] TMP_Text _ammoTxt;

    private void OnEnable()
    {
        Weapon.AmmoChange += OnAmmoChange;
    }

    private void OnDisable()
    {
        Weapon.AmmoChange -= OnAmmoChange;
    }

    void OnAmmoChange(int ammo)
    {
        _ammoTxt.text = ammo.ToString();
        if(ammo == 0)
        { 
            _ammoImg.color = Color.red;
            _ammoTxt.color = Color.red;
        }
        else
        {
            _ammoImg.color = Color.white;
            _ammoTxt.color = Color.white;
        }
    }
}
