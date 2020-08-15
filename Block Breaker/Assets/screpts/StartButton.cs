using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    GameStatus status;
    [SerializeField] Sprite[] startSprite;
    [SerializeField] int whereArewe = 0;
    void Start()
    {
        status = FindObjectOfType<GameStatus>();


    }

    void Update()
    {
    }
    public void StopAndStartGame()
    {
        if (whereArewe == 0) {
            status.SetGameSpeed(0);
            GetComponent<Image>().sprite = startSprite[1];
            whereArewe = 1;
        }
        else
        {
            status.SetGameSpeed(1);
            GetComponent<Image>().sprite = startSprite[0];
            whereArewe = 0;

        }

    }
}
