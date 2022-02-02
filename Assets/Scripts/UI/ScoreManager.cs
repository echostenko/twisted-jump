using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;  
    public Text scoreText;
    private int score = 0;

    private void Awake() => 
        Instance = this;

    private void Start() => 
        scoreText.text = score.ToString();

    public void PlusPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    
    public void MinusPoint()
    {
        if (score <= 0) return;
        score -= 1;
        scoreText.text = score.ToString();
    }
    
}
