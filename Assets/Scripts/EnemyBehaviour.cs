using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform patrolRoute;
    public Transform player;
    public List<Transform> locations;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    private int _lives = 3;
    public int EnemyLives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down");
            }
        }
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
        if (locations.Count == 0)
        {
            return;
        }
        _locationIndex = (_locationIndex + 1) % locations.Count;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
            _agent.destination = player.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range - resume patrol");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Enemy hit");
        }
    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    void MoveToNextPatrolLocation()
    {
        _agent.destination = locations[_locationIndex].position;
    }
}
