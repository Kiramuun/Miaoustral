using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvEnnemieActif : MonoBehaviour
{
    [Header("Reference :")]
    [SerializeField] Transform _player;
    [SerializeField] Transform[] _dest = new Transform[4];
    NavMeshAgent _agent;

    [Header("Zone detection :")]
    [SerializeField] float _rayonDetection;
    [SerializeField] float _rayonAttaque;

    [Header("Parametres :")]
    [SerializeField] float delaiAttaque;
    int _index;

    bool hasDestination,
         isAttacking;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _agent.autoBraking = true;
        _agent.SetDestination(_dest[0].position);
        _index = 1;
    }

    void Update()
    {
        if (Vector3.Distance(_player.position, transform.position) < _rayonDetection)
        {
            if (!isAttacking)
            {
                if (Vector3.Distance(_player.position, transform.position) < _rayonAttaque)
                {
                    StartCoroutine(AttaqueLeJoueur());
                }
                else { _agent.SetDestination(_player.position); }
            }
        }
        else
        {
            Destinations();
        }
    }

    public void Destinations()
    {
        if (_agent.remainingDistance == 0)
        {
            switch (_index)
            {
                case 1:
                    _agent.SetDestination(_dest[1].position);
                    _index++;
                    break;
                case 2:
                    _agent.SetDestination(_dest[2].position);
                    _index++;
                    break;
                case 3:
                    _agent.SetDestination(_dest[3].position);
                    _index++;
                    break;
                case 4:
                    _agent.SetDestination(_dest[0].position);
                    _index = 1;
                    break;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _rayonDetection);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, _rayonAttaque);
    }

    IEnumerator AttaqueLeJoueur()
    {
        isAttacking = true;
        _agent.isStopped = true;

        yield return new WaitForSeconds(delaiAttaque);
        _agent.isStopped = false;
        isAttacking = false;
    }
}
