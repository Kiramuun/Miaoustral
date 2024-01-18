using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDuCourant : MonoBehaviour
{
    ConstantForce _constForce;

    void Awake()
    {
        _constForce = GameObject.Find("Player").GetComponent<ConstantForce>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision"+other.name);
        Debug.Log(other.gameObject.layer);

        if(other.gameObject.layer == 3)
        {
            _constForce.relativeForce = new Vector3(0,50,0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("fin collision");
        if (other.gameObject.layer == 3)
        {
            _constForce.relativeForce = Vector3.zero;
        }
    }
}
