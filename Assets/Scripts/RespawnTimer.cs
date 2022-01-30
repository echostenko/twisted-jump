using UnityEngine;
using UnityEngine.UI;

public class RespawnTimer : MonoBehaviour
{
    private float currentTime = 0f;
    private float startTime = 5f;
    public GameObject Timer;
    public Transform parent;
    [SerializeField] private Text respawnTimer;
    
    

    private void Start()
    {
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        respawnTimer.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            DestroyImmediate(gameObject);
        }
    }
}
