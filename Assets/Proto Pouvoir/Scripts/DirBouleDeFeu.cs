using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirBouleDeFeu : MonoBehaviour
{
    void Update()
    {
        this.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 2));
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
