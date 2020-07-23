
using UnityEngine;



public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float pushX;
    [SerializeField] float pushY;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = .2f;
    Rigidbody2D myRigidBody2D ;
    
    Vector2[] repeated = new Vector2[3];
    int i = 0;
    //cached Component
    AudioSource MyAudioSource;
    bool hasStarted = false;
    // Start is called before the first frame update

    //satate 
    Vector2 paddleToBallVector; 
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        MyAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) { 
        LockBallToPaddle();
        LaunchBallOnMouseClick();
    }
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(pushX, pushY);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddleToBallVector + paddlePos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f,randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStarted) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            MyAudioSource.PlayOneShot(clip);
            FixBoring();
            myRigidBody2D.velocity += velocityTweak;
        }

       
    }

    private void FixBoring()
    {  
     }
}
