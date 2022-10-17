using UnityEngine;

namespace UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] public GameObject gameOver;
        public Transform parent;

        private void Awake()
        {
            GameTimer.TimerZeroEvent += SpawnGameOver;
            LifesCounter.GameOverEvent += SpawnGameOver;
        }

        private void OnDestroy()
        {
            GameTimer.TimerZeroEvent -= SpawnGameOver;
            LifesCounter.GameOverEvent -= SpawnGameOver;
        }

        private void SpawnGameOver()
        { 
            Instantiate(gameOver, new Vector3(0, 0, 0), gameOver.transform.rotation, parent);
        }
    }
}
