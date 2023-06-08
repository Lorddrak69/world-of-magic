using UnityEngine;
using UnityEngine.AI;
public class enemy_AI : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target;
    
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("XR Origin").transform;
    }
    void Update()
    {
        pathfinder.SetDestination(target.position);
    }
}