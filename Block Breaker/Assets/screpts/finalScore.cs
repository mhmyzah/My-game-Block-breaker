using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class finalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameScore;

    void Start()
    {
        
    }
    public void setScore(string score)
    {
        gameScore.text = score;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            Destroy(gameObject);


    }
}
