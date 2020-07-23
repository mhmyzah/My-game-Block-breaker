using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float gameSpeed=1f;
    [SerializeField] int pointsPerBlock=85;
    [SerializeField] int totalPoints = 0;
    [SerializeField] TextMeshProUGUI gameScore;
    int numberof = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameScore.text = totalPoints.ToString();
       ;
    }
    private void Awake()
    {
        int numberof  = FindObjectsOfType<GameStatus>().Length;
        if (numberof > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }

    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    public void AddScore()
    {
        totalPoints += pointsPerBlock;
        gameScore.text = totalPoints.ToString();
    }
    public void ObjectDestroy()
    {
        Destroy(gameObject);
    }

}
