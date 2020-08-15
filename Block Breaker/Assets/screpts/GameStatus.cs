using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameStatus : MonoBehaviour
{
    [Range(0.0f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 85;
    [SerializeField] int totalPoints = 0;
    [SerializeField] int levelPoints = 0;
    [SerializeField] TextMeshProUGUI gameScore;
    [SerializeField] private bool traceBallEnable = false;
    [SerializeField] int levelnumber = 2;
    GameObject[] buttons;

    int numberof = 0;

    void Start()
    {
        DisplayGameScore();

    }
    private void Awake()
    {
        int numberof = FindObjectsOfType<GameStatus>().Length;
        if (numberof > 1)
        {
            Destroy(gameObject);
             gameObject.SetActive(false);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }

    }
 
    void Update()
    {
        Time.timeScale = gameSpeed;
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            FindObjectOfType<finalScore>().setScore(totalPoints.ToString());
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
       if( SceneManager.GetActiveScene().buildIndex == 7)
        {

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    public void SetGameSpeed(float GameSpeed)
    {
        gameSpeed = GameSpeed;

    }
    public int GetLevelNubmer()
    {
        return levelnumber;
    }
    public void DisplayGameScore()
    {
        gameScore.text = totalPoints.ToString();

    }
    public bool ReturntraceBallEnable()
    {
        return traceBallEnable;
    }
    public void ResetLevelPoints()
    {
        levelPoints = 0;
    }
    public string ReturnScore()
    {
        return totalPoints.ToString();
    }
   
    public void SubLevelPoints()
    {
        totalPoints -= levelPoints; 
    }
    public void setLevelNumber(int levelnumb)
    {
        levelnumber = levelnumb;
    }
   
    public void AddScore()
    {
        levelPoints+=pointsPerBlock;
        totalPoints += pointsPerBlock;
        gameScore.text = totalPoints.ToString();
    }
    


}