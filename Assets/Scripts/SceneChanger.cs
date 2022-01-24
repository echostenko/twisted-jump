using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private int levelToLoad;
    private GameObject popUp;
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadThirdLevel()
    {
        SceneManager.LoadScene(3);
    }
}
    