using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject BlockSpecialEffectVFX;
    [SerializeField] Sprite[] stateOfDamageBlock;
    //chached param
    Level level;
    SpriteRenderer mySpriteRenderer;
    Rigidbody2D myrigidbody2D;
    private Vector2 MovingDirection = Vector2.left;
   
    //state variable
    [SerializeField] int timesHit;//serialize only for debugging
    int  speed = 3;

    
    private void Start()
    {
        CountBreakableBlocks();
        mySpriteRenderer=GetComponent<SpriteRenderer>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MovingBlock();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
            BlockDestoryed();
        else
        {
            BlockStopped(collision);
        }
    }
   
    private void BlockStopped(Collision2D collision)
    {
        //GetContact is the collision point
        if (transform.position.x > collision.GetContact(0).point.x)
        {
            MovingDirection = Vector2.right;
        }
        else if (transform.position.x < collision.GetContact(0).point.x)
        {
            MovingDirection = Vector2.left;
        }
        gameObject.GetComponent<SpriteRenderer>().flipX = true;
        transform.Translate(MovingDirection * speed * Time.deltaTime);
        myrigidbody2D.velocity = myrigidbody2D.velocity.normalized * 7.5f;

    }
    private void CountBreakableBlocks()
    {
        //"find object of type" gives us access to the 'Level' script
        //so we can call the breakableBlocks function
        if (tag == "Breakable" || tag =="MovingBlock")
        {
            level = FindObjectOfType<Level>();
            level.CountBreakableBlocks();
        }
    }

    private void BlockDestoryed()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if(tag=="Breakable" || tag=="MovingBlock" || tag== "SpecialBlock")
        {
            timesHit++;
            if(timesHit==stateOfDamageBlock.Length+1)
            {
                FindObjectOfType<GameState>().AddToScore();
                Destroy(gameObject);
                level.BlockBreaked();
                SpecialEffectsVFX();
            }
            else
            {
                if (stateOfDamageBlock[timesHit - 1] != null)
                {
                    mySpriteRenderer.sprite = stateOfDamageBlock[timesHit - 1];
                    FindObjectOfType<GameState>().AddHalfToScore();
                }
                else
                {
                    Debug.LogError("Block sprite is missing from array" +" " + gameObject.name);
                }
            }
            if (tag == "SpecialBlock")
                FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
  
    private void SpecialEffectsVFX()
    {
        GameObject sparkles = Instantiate(BlockSpecialEffectVFX, transform.position, transform.rotation);
        Destroy(sparkles,1f);
    }

    private void MovingBlock()
    {
        if(tag=="MovingBlock")
        {
            if (transform.position.x > 16f)
            {
                MovingDirection = Vector2.left;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x < 0f)
            {
                MovingDirection = Vector2.right;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.Translate(MovingDirection * speed * Time.deltaTime);
            myrigidbody2D.velocity = myrigidbody2D.velocity.normalized * 8f;
            
        }
    }
}
