using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionJoueur : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _rayonDetection;

    public GameObject _textTouche,
                      _textParole;

    void Update()
    {
        if(Vector3.Distance(_player.position, transform.position) < _rayonDetection)
        {
            _textTouche.SetActive(true);
        }
        else
        {
            _textTouche.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, _rayonDetection);
    }
}
