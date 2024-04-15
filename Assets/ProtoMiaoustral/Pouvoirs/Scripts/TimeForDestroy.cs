using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeForDestroy : MonoBehaviour
{
    [SerializeField] float timer;
    
    void Start()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
