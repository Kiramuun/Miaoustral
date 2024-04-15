using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AffichageTouche : MonoBehaviour
{
    public GameObject _textTouche,
                      _textParole;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _textParole.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            _textTouche.SetActive(true);
            Update();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            _textTouche.SetActive(false);
            _textParole.SetActive(false);
        }
    }
}
