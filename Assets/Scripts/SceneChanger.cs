using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animanor;
    private int levelToLoad;
    private GameObject popUp;
    
    
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animanor.SetTrigger("Fade_out");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
    