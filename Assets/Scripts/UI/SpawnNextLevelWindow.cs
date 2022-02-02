using UnityEngine;

namespace UI
{
    public class SpawnNextLevelWindow : MonoBehaviour
    {
        public GameObject nextLevelWindow;
        public Transform parent;

        private void Awake() => 
            BossDestroyer.bossDestroyedEvent += SpawnWindow;
    
        private void OnDestroy() => 
            BossDestroyer.bossDestroyedEvent -= SpawnWindow;

        private void SpawnWindow() => 
            Instantiate(nextLevelWindow, new Vector3(0, 0, 0), nextLevelWindow.transform.rotation, parent);
    }
}
