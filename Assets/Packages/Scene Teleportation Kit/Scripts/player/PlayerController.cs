using UnityEngine;
using UnityEngine.AI;

namespace Scene_Teleportation_Kit.Scripts.player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerController : MonoBehaviour {
        public PlayerMovement playerMovement;

        private Animator animator;
        private NavMeshAgent agent;

        void Start() {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) {
                    playerMovement.Move(hit.point);
                }
            }

            if (!agent.pathPending) {
                if (agent.remainingDistance <= agent.stoppingDistance) {
                    animator.SetFloat("Speed", 0f);
                } else {
                    animator.SetFloat("Speed", agent.speed);
                }
            }
        }
    }
}
