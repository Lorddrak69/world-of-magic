using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene_Teleportation_Kit.Scripts.teleport
{
    public class Teleporter : MonoBehaviour {
        public Object destinationScene;
        public string destSpawnName;

        void OnTriggerEnter(Collider collider) {
            Teleportable teleportable = collider.GetComponent<Teleportable>();
            if (teleportable != null) {
                OnEnter(teleportable);
            }
        }

        public void OnEnter(Teleportable teleportable) {
            if (!teleportable.canTeleport) {
                return;
            }
            teleportable.canTeleport = false;

            if (SceneManager.GetActiveScene().name == destinationScene.name) {
                Teleport(teleportable);
            } else {
                StartCoroutine(TeleportToNewScene(destinationScene.name, teleportable));
            }
        }

        private IEnumerator TeleportToNewScene(string sceneName, Teleportable teleportable) {
            Scene currentScene = SceneManager.GetActiveScene();
            AsyncOperation newSceneAsyncLoad = SceneManager.LoadSceneAsync(destinationScene.name, LoadSceneMode.Additive);

            while (!newSceneAsyncLoad.isDone) {
                yield return null;
            }

            SceneManager.MoveGameObjectToScene(teleportable.gameObject, SceneManager.GetSceneByName(sceneName));
            Teleport(teleportable);

            SceneManager.UnloadSceneAsync(currentScene);
        }

        private void Teleport(Teleportable teleportable) {
            SpawnPoint spawnPoint = FindSpawnPoint(destSpawnName);
            if (spawnPoint != null) {
                teleportable.GetComponent<PlayerMovement>().TeleportTo(spawnPoint.transform);
            }
            teleportable.canTeleport = true;
        }

        private SpawnPoint FindSpawnPoint(string spawnName) {
            SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();
            foreach (SpawnPoint spawn in spawnPoints) {
                SpawnPoint spawnPoint = spawn.GetComponent<SpawnPoint>();
                if (spawnPoint.spawnName == spawnName) {
                    return spawnPoint;
                }
            }
            return null;
        }
    }
}
