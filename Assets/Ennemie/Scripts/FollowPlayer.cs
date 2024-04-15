using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Dest4 _dest = new Dest4();

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            Debug.Log("Je te vois JOUEUR !!!");
        }
    }
}
