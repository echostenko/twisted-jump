using Player;
using UnityEngine;

namespace UI
{
    public class RespawnTimerSpawnManager : MonoBehaviour
    {
        public GameObject respawnTimer;
        public Transform parent;
        private bool isOver;

    
        private void Awake()
        {
            LifesCounter.GameOverEvent += IsGameOver;
            PlayerRespawn.PlayerRespawnedEvent += PlayerRespawnOnplayerRespawnedEvent;
        }

        private void OnDestroy()
        {
            LifesCounter.GameOverEvent -= IsGameOver;
            PlayerRespawn.PlayerRespawnedEvent -= PlayerRespawnOnplayerRespawnedEvent;
        }

        private void IsGameOver() => 
            isOver = true;

        private void PlayerRespawnOnplayerRespawnedEvent()
        {
            if (!isOver) 
                Instantiate(respawnTimer, new Vector3(0, 0, 0), respawnTimer.transform.rotation, parent);
        }
    }
}
    