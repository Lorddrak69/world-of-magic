using UnityEngine;

namespace Scene_Teleportation_Kit.Scripts.teleport
{
    public class PortTrigger : MonoBehaviour {
        public Teleporter teleporter;

        private void OnTriggerEnter(Collider collider) {
            var teleportable = collider.GetComponent<Teleportable>();
            if (teleportable != null) {
                teleporter.OnEnter(teleportable);
            }
        }
    }
}