using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]Paddle myPaddle;

    //array declaration
    [SerializeField] AudioClip[] ballSounds ;

    Vector2 paddleToBallDistance;

    bool hasStarted = false;



    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = this.transform.position - myPaddle.transform.position;

        //ball - paddlePosition
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) //hasStarted == false
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //System.Random used only in csharp
        //generte random number
        int randomNumber = Random.Range(0,ballSounds.Length);
        //save random audio in clip
        AudioClip clip = ballSounds[randomNumber];

        GetComponent<AudioSource>().Play();
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            hasStarted = true;
            //shoot the ball
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
        }  
    }


    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = myPaddle.transform.position;
        //set the ball position = paddle position +
        this.transform.position = paddlePosition + paddleToBallDistance;
    }
    
}
