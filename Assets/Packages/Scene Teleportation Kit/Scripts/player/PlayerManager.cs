using UnityEngine;

namespace Scene_Teleportation_Kit.Scripts.player
{
    public class PlayerManager : MonoBehaviour {
        public GameObject playerPrefab;

        public static PlayerManager Instance { get; private set; }

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        void Start() {
            if (playerPrefab != null) {
                var position = new Vector3(0, 0, -8);
                var spawnPoint = FindFirstSpawnPoint();
                if (spawnPoint != null) {
                    position = spawnPoint.transform.position;
                }

                Instantiate(playerPrefab, position, Quaternion.identity);
            }
        }

        private SpawnPoint FindFirstSpawnPoint() {
            SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();
            if (spawnPoints.Length > 0) {
                return spawnPoints[0];
            }
            return null;
        }
    }
}
