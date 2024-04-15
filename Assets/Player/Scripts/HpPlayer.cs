using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HpPlayer : MonoBehaviour
{
    [SerializeField] float _vie;
    [SerializeField] float _maxVie = 100f;
    [SerializeField] Image _barreDVie;
    [SerializeField] TextMeshProUGUI _textPdV;
    [SerializeField] InputActionAsset _inputAA;

    void Awake()
    {
        _vie = _maxVie;
    }

    void Update()
    {
        _textPdV.text = _vie + " / " + _maxVie;
        if (_inputAA.FindActionMap("Default").FindAction("Soins").IsPressed())
        {
            SoinsRecu(10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            DommageRecu(15);
        }
    }

    public void SoinsRecu(float soins)
    {
        _vie += soins;
        UpdateBarreDeVie();
    }

    void DommageRecu(float dommage)
    {
        _vie -= dommage;
        UpdateBarreDeVie();
    }

    void UpdateBarreDeVie()
    {
        _barreDVie.fillAmount = _vie / _maxVie;
    }
}
