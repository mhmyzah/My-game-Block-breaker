using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float min;
    [SerializeField] float max;
    [SerializeField] float ScreenWidth = 16f;
    [SerializeField] Sprite[] paddleSprites;
    [SerializeField] GameObject laser;
    GameStatus status;
    // Start is called before the first frame update
    void Start()
    {
        status = FindObjectOfType<GameStatus>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
            TurnToleaser();
            float mousePosInUnits =Input.mousePosition.x/Screen.width* ScreenWidth;
        if (!TraceBall())
        {
            Vector2 paddlePose = new Vector2(transform.position.x, transform.position.y);
            paddlePose.x = Mathf.Clamp(mousePosInUnits, min, max);
            transform.position = paddlePose;
        } else {
            Vector2 paddlePose = new Vector2(FindObjectOfType<Ball>().transform.position.x,transform.position.y);
            paddlePose.x = Mathf.Clamp(FindObjectOfType<Ball>().transform.position.x, min, max);
            transform.position = paddlePose;
        }


    }
    public void TurnToleaser()
    {
      
        {
            // GetComponent<SpriteRenderer>().sprite = paddleSprites[1];
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
    public bool TraceBall()
    {
       return  status.ReturntraceBallEnable();
    }
}
