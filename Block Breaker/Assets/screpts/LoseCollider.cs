using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    string delete ;
    GameStatus status;
    
    private void Start()
    {
        status = FindObjectOfType<GameStatus>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.LoadScene("game Over");
        status.SubLevelPoints();
        status.DisplayGameScore();
        status.ResetLevelPoints();

       
    }
}
