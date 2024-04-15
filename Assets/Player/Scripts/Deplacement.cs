using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deplacement : MonoBehaviour
{
    private InputAction _mouv,
                        _jump;
    public InputActionAsset _inputAA;
    public Transform _shootPoint,
                     _pointApparition,
                     _grpBdF;
    public GameObject _bouleDFeu,
                      _soins;
    public float _speed,
                 _speedRotate = 0.1f,
                 _coolDownBdf = 5f;
    Rigidbody _rb;
    public TextMeshProUGUI _textCoolDownBdF;
    Vector3 _mouvDir;
    Vector2 mouvInput;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mouv = _inputAA.FindActionMap("Default").FindAction("Deplacement");
        _jump = _inputAA.FindActionMap("Default").FindAction("Sauter");
        _mouv.Enable();
        _jump.Enable();
    }

    private void Update()
    {
        if(_inputAA.FindActionMap("Default").FindAction("Boule de Feu").enabled)
        {
            _textCoolDownBdF.text = "BdF : " + _coolDownBdf;
            StartCoroutine(CoolDownBdF());
        }
    }

    /*bool IsGrounded()
    {
        return GetComponent<Rigidbody>().velocity.y == 0;
    }*/

    public void Deplacements(InputAction.CallbackContext context)
    {
        mouvInput = _mouv.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, _mouvDir, Color.black, 5f);
        _mouvDir = Camera.main.transform.right * mouvInput.x + Camera.main.transform.forward * mouvInput.y;
        _mouvDir.y = 0;
        Vector3 velocity = _mouvDir * _speed;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;

        if(_mouvDir.sqrMagnitude > 0) { _rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_mouvDir), _speedRotate)); }
        
    }

    /*public void Jump(InputAction.CallbackContext context)
    {
        if(IsGrounded()) { if (context.performed) { _rb.AddForce(Vector3.up * 500); } }
    }*/

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started) { _speed *= 2f; }
        if (context.canceled) { _speed /= 2f; }
    }

    public void Soins(InputAction.CallbackContext context)
    {
        if (context.performed) 
        { 
            GameObject newSoins = Instantiate(_soins, _pointApparition.transform.position, Quaternion.identity);
            newSoins.transform.parent = _pointApparition;
        }
    }

    public void BouleDeFeu(InputAction.CallbackContext context)
    {
        GameObject newBdF = Instantiate(_bouleDFeu, _shootPoint.transform.position, Quaternion.LookRotation(transform.forward));
        newBdF.transform.parent = _grpBdF;
    }

    IEnumerator CoolDownBdF()
    {
        yield return new WaitForSeconds(_coolDownBdf);
    }
}
