using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    
    //configuration parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 1f, yPush = 20f;
    // [SerializeField] AudioClip[] ballSounds;
    
    double lastXPos, lastYPos;
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    Rigidbody2D myrigidbody2D;
    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
      
        if(hasStarted==false)
        {
            BlockBallToPaddle();
            LaunchBallOnMouseClick();
        }
        lastXPos = transform.position.x;
        lastYPos = transform.position.y;
        //LaunchBallOnMouseClick();
    }
    private void BlockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,
           paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void LaunchBallOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myrigidbody2D.velocity = new Vector2(xPush,yPush);
            myrigidbody2D.velocity = myrigidbody2D.velocity.normalized * 7.5f;

        }
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            // AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            // myaudioSource.PlayOneShot(clip);
            myAudioSource.Play();
        }
        if ((lastYPos - transform.position.y >= 0.1 && lastYPos - transform.position.y <= 0.9) || (lastXPos - transform.position.x >= 0.1 && lastXPos - transform.position.x <= 0.9))
        {
            myrigidbody2D.velocity += new Vector2(1.5f, 1.5f);
        }
        myrigidbody2D.velocity = myrigidbody2D.velocity.normalized * 7.5f;

    }
}







