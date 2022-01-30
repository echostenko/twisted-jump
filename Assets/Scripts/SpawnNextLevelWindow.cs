using UnityEngine;

public class SpawnNextLevelWindow : MonoBehaviour
{
    public GameObject nextLevelWindow;
    public Transform parent;
    public BossDestroyer BossDestroyer;

    private void Awake()
    {
        BossDestroyer.bossDestroyedEvent += SpawnWindow; 
    }

    private void SpawnWindow()
    {
        Instantiate(nextLevelWindow, new Vector3(0, 0, 0), nextLevelWindow.transform.rotation, parent);
    }

    private void OnDestroy()
    {
        BossDestroyer.bossDestroyedEvent -= SpawnWindow;     
    }
}
