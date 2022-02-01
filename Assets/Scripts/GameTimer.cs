using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startTime = 100f;
    [SerializeField] public Text gameTimer;
    [SerializeField] public GameObject gameOver;
    public Transform parent;
    public GameObject player;
    public BossDestroyer BossDestroyer;

    public void Awake()
    {
        BossDestroyer.bossDestroyedEvent += StopGameTimer;
    }

    private void StopGameTimer()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        BossDestroyer.bossDestroyedEvent -= StopGameTimer;
    }

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
            Instantiate(gameOver, new Vector3(0, 0, 0), gameOver.transform.rotation, parent);
        }
        
    }
}
