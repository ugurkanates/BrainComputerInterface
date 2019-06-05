 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    private float speed = 3f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    private bool direction = false; //false means asagi , true means yukari

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = !direction;
            if (direction)
                vel.y = speed;
            else
                vel.y = -speed;
        }
        
        else if (direction)
            vel.y = speed;
        else
            vel.y = -speed;
            

        /*if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        */
        rb2d.velocity = vel;
        print(rb2d.velocity.y);
        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
            direction = false; //asagi in
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
            direction = true; // yukari cik
        }
        transform.position = pos;
    }
}
