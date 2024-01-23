using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSpawn : MonoBehaviour
{
    public Transform _transformTp;
    public GameObject _player;

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        _player.transform.position = new Vector3(_transformTp.transform.position.x, _transformTp.transform.position.y, _transformTp.transform.position.z);
    }
}
