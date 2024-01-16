using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDuCourant : MonoBehaviour
{
    public GameObject _gObject;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            _gObject.AddComponent<ConstantForce>();
        }
    }
}
