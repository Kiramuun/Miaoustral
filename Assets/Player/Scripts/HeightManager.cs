using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GroundDetection))]
//[RequireComponent(typeof(StepDetector))]

public class HeightManager : MonoBehaviour
{
    [SerializeField] Transform[] _groundRayCast;
    GroundDetection _groundDetector;
    //StepDetector _stepDetector;
    Rigidbody _rigidB;

    void Awake()
    {
        _groundDetector = GetComponent<GroundDetection>();
        //_stepDetector = GetComponent<StepDetector>();
        _rigidB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (_groundDetector._isGround)
        {
            _rigidB.useGravity = false;
            _rigidB.velocity = new Vector3(_rigidB.velocity.x, 0, _rigidB.velocity.z);
        }
        else
        {
            _rigidB.useGravity = true;
        }
    }
}
