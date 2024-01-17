using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deplacement : MonoBehaviour
{
    private InputAction _mouv;
    public InputActionAsset _inputAA;

    public float _speed,
                 _speedRotate = 0.1f;
    Rigidbody _rb;
    Vector3 _mouvInput;


    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mouv = _inputAA.FindActionMap("Default").FindAction("Deplacement");
        _mouv.Enable();
    }

    void Update()
    {
        var mouvDir = _mouv.ReadValue<Vector2>();

        _mouvInput = Camera.main.transform.right * mouvDir.x + Camera.main.transform.forward * mouvDir.y;
        _mouvInput.y = 0;
        Debug.DrawRay(transform.position, _mouvInput);
        //if(_mouvInput.sqrMagnitude > 0) { transform.eulerAngles =  }
    }

    void FixedUpdate()
    {
        Vector3 velocity = _mouvInput * _speed;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;

        if(_mouvInput.sqrMagnitude > 0) { _rb.MoveRotation(Quaternion.LookRotation(_mouvInput)); }
        Debug.Log(_mouvInput.sqrMagnitude);
    }
}
