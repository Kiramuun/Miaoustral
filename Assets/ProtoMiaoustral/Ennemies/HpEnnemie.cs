using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpEnnemie : MonoBehaviour
{
    [SerializeField] float _vie;
    [SerializeField] float _maxVie;
    [SerializeField] Image _barreDVie;
    [SerializeField] TextMeshProUGUI _textPdV;

    void Awake()
    {
        _vie = _maxVie;
    }

    void Update()
    {
        _textPdV.text = _vie + " / " + _maxVie;
        if(_vie == 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            DommageRecu(1);
        }
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
