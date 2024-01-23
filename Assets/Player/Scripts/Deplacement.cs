using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
                 _speedRotate = 0.1f;
    Rigidbody _rb;
    Vector3 _mouvInput;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mouv = _inputAA.FindActionMap("Default").FindAction("Deplacement");
        _jump = _inputAA.FindActionMap("Default").FindAction("Sauter");
        _mouv.Enable();
        _jump.Enable();
    }

    bool IsGrounded()
    {
        return GetComponent<Rigidbody>().velocity.y == 0;
    }

    public void Deplacements(InputAction.CallbackContext context)
    {
        var mouvDir = _mouv.ReadValue<Vector2>();

        _mouvInput = Camera.main.transform.right * mouvDir.x + Camera.main.transform.forward * mouvDir.y;
        _mouvInput.y = 0;
        //Debug.DrawRay(transform.position, _mouvInput);
    }

    void FixedUpdate()
    {
        Vector3 velocity = _mouvInput * _speed;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;

        if(_mouvInput.sqrMagnitude > 0) { _rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_mouvInput), _speedRotate)); }
        //Debug.Log(_mouvInput.sqrMagnitude);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(IsGrounded()) { if (context.performed) { _rb.AddForce(Vector3.up * 500); } }
    }

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
        if (context.performed) 
        { 
            GameObject newBdF = Instantiate(_bouleDFeu, _shootPoint.transform.position, Quaternion.identity);
            newBdF.transform.parent = _grpBdF;
        }
    }

    

    
}
