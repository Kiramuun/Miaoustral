using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [SerializeField] float _distance,
                           _gravity;
    [SerializeField] LayerMask _groundMask;
    public bool _isGround;

    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contactPoint in collision.contacts)
        {
            Debug.DrawRay(contactPoint.point, contactPoint.normal * 0.5f, Color.blue);
        }
    }

    /*void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, _distance, _groundMask))
        {
            _isGround = true;
            Debug.DrawRay(transform.position, hit.point, Color.red);
        }
        else
        {
            _isGround = false;
            Debug.DrawRay(transform.position, Vector3.down * _distance, Color.red);
        }
    }*/
}
