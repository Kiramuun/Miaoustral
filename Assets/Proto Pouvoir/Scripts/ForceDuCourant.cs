using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDuCourant : MonoBehaviour
{
    public GameObject _gObject;
    ConstantForce _constForce;

    void Awake()
    {
        _constForce = GetComponent<ConstantForce>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision"+other.name);
        Debug.Log(other.gameObject.layer);

        if(other.gameObject.layer == 6)
        {
            gameObject.GetComponent<ConstantForce>().relativeForce = new Vector3(0,100,0);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("fin collision");
        if (other.gameObject.layer == 6)
        {
            gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
        }
    }
}
