using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameTimer : MonoBehaviour
    {
        private float currentTime;
        private float startTime = 100f;
        [SerializeField] public Text gameTimer;
        public GameObject player;

        public static event Action TimerZeroEvent;
    
        private void Awake() => 
            BossDestroyer.bossDestroyedEvent += StopGameTimer;

        private void Start() => 
            currentTime = startTime;

        private void Update()
        {
            currentTime -= 1 * Time.deltaTime;
            gameTimer.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                DestroyImmediate(gameObject);
                Destroy(player);
                TimerZeroEvent?.Invoke();
            }
        }
    
        private void OnDestroy() => 
            BossDestroyer.bossDestroyedEvent -= StopGameTimer;
    
        private void StopGameTimer() => 
            Destroy(gameObject);
    }
}
