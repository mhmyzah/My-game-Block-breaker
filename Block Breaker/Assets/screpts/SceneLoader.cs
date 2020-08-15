using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    GameObject[] buttons;

    GameStatus status;
    private void Start()
    {
        status = FindObjectOfType<GameStatus>();

    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        status.ResetLevelPoints();
        status.setLevelNumber(SceneManager.GetActiveScene().buildIndex+1);


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNextScene();
        }

    }

    public void PlayAgain()
    {
        
        SceneManager.LoadScene(1);
      

    }
    public void Continu()
    {
        if (status != null)
        {
            SceneManager.LoadScene(status.GetLevelNubmer());
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
