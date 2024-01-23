using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCercleSoins : MonoBehaviour
{
    ParticleSystem _psSoins;

    void Awake()
    {
        _psSoins = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (_psSoins.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
