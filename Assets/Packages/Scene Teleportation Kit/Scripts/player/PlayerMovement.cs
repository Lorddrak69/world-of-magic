using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour {
    private NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 position) {
        agent.SetDestination(position);
    }

    public bool IsStillMoving() {
        return agent.remainingDistance > agent.stoppingDistance;
    }

    private void StopAgent() {
        agent.isStopped = true;
        agent.ResetPath();
        agent.enabled = false;
    }

    private void EnableAgent() {
        agent.enabled = true;
    }

    public void TeleportTo(Transform destination) {
        StopAgent();
        transform.position = destination.position;
        EnableAgent();
    }
}
