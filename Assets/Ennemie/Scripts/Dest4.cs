using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dest4 : MonoBehaviour
{
    [Header("Reference :")]
    [SerializeField] Transform _player;
    NavMeshAgent _agent;
    Animator _anim;

    [Header("Zone detection :")]
    [SerializeField] float _rayonDetection;
    [SerializeField] float _rayonAttaque;

    [Header("Ballades :")]
    [SerializeField] float _tempBalladesMin;
    [SerializeField] float _tempBalladesMax;
    [SerializeField] float _distanceBalladesMin;
    [SerializeField] float _distanceBalladesMax;

    [Header("Parametres :")]
    [SerializeField] float delaiAttaque;
    [SerializeField] float vitesseMarche;
    [SerializeField] float vitessePoursuite;

    bool hasDestination,
         isAttacking;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Vector3.Distance(_player.position,transform.position) < _rayonDetection)
        {
            _agent.speed = vitessePoursuite;
            
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
            _agent.speed = vitesseMarche;

            if (_agent.remainingDistance < 0.75f && !hasDestination) 
            { 
                StartCoroutine(GetNewDestination()); 
            } 
        }

        _anim.SetFloat("Speed", _agent.velocity.sqrMagnitude);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _rayonDetection);
        
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, _rayonAttaque);
    }

    IEnumerator GetNewDestination()
    {
        hasDestination = true;
        yield return new WaitForSeconds(Random.Range(_tempBalladesMin, _tempBalladesMax));

        Vector3 nextDestination = transform.position;
        nextDestination += Random.Range(_distanceBalladesMin, _distanceBalladesMax) * new Vector3(Random.Range(-1f, 1), 0f, Random.Range(-1f, 1f)).normalized;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(nextDestination, out hit, _distanceBalladesMax, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }
        hasDestination = false;
    }

    IEnumerator AttaqueLeJoueur()
    {
        isAttacking = true;
        _agent.isStopped = true;

        _anim.SetTrigger("Attack");

        yield return new WaitForSeconds(delaiAttaque);
        _agent.isStopped = false;
        isAttacking = false;
    }
}
