using UnityEngine;
using UnityEngine.UI;

public class LifesCounter : MonoBehaviour
{
    public static LifesCounter instance;
    public GameObject gameOverScreen;
    public Transform parent;
    public Text lifeText;
    private int continues = 5;
    public PlayerRespawn PlayerRespawn;


    public void Awake() => 
        PlayerRespawn.playerRespawnedEvent += MinusContinue;

    private void Start() => 
        lifeText.text = continues.ToString();

    private void OnDestroy() => 
        PlayerRespawn.playerRespawnedEvent -= MinusContinue;

    private void MinusContinue()
    {
        if (continues == 1)
            Instantiate(gameOverScreen, new Vector3(0, 0, 0), gameOverScreen.transform.rotation, parent);
        
        continues -= 1;
        lifeText.text = continues.ToString();    
    }
}
