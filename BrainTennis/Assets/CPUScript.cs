using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUScript : MonoBehaviour
{

    public GameObject theBall;
    public float speed = 30;
    public float lerpSpeed = 1f;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        theBall = GameObject.Find("Ball");
    }

    void FixedUpdate()

    {
        System.Random rand = new System.Random();
        if (rand.Next(10) == 1) // %10 sans BURDAN USER INTERFACEDEN PRO YAPABİLİRSİNIZ 
        {
            if (theBall.transform.position.y > transform.position.y)
            {
                if (rigidBody.velocity.y < 0) rigidBody.velocity = Vector2.zero;
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * speed, lerpSpeed * Time.deltaTime);
            }
            else if (theBall.transform.position.y < transform.position.y)
            {
                if (rigidBody.velocity.y > 0) rigidBody.velocity = Vector2.zero;
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * speed, lerpSpeed * Time.deltaTime);
            }
            else
            {
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * speed, lerpSpeed * Time.deltaTime);
            }
        }
        else
        {
            //do nothin
        }
    }
}
