using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float min;
    [SerializeField] float max;
    [SerializeField] float ScreenWidth = 10.6666666667f*2;
    [SerializeField] Sprite[] paddleSprites;
    [SerializeField] GameObject laser;
    bool laserMode = false;
    Ball ball;
    GameStatus status;
    void Start()
    {
        status = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            laserMode = true;
            TurnToleaser();
        }

             Vector2 paddlePose = new Vector2(transform.position.x, transform.position.y);
            paddlePose.x = Mathf.Clamp(TraceBall(), min, max);
            transform.position = paddlePose;

        if (laserMode && Input.GetMouseButtonDown(0))
              TurnToleaser();
       



    }
    public void TurnToleaser()
    {
        laserMode = true;
        {
            GetComponent<SpriteRenderer>().sprite = paddleSprites[1];
            Vector2 laserPos;
            laserPos.x = transform.position.x+1.2f;
            laserPos.y = transform.position.y+.5f;
            GameObject shotedLaserLeft = Instantiate(laser, laserPos, transform.rotation);
            laserPos.x  = laserPos.x- 1.2f * 2;
            GameObject shotedLaserRight = Instantiate(laser, laserPos, transform.rotation);

            shotedLaserLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20f);
            shotedLaserRight.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20f);


        }
    }
    public float TraceBall()
    {
        if (status.ReturntraceBallEnable())
        {
            return ball.transform.position.x;
        } else
        {
            
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        }
    }
}
