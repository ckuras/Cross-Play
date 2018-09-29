using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float move;
    public float speed = 8.0f;

    void Start ()
    { 
        if (gameObject.tag == "p1")
        {
            gameObject.transform.Translate(-1.0f, 0.0f, 0.0f);
        } else
        {
            gameObject.transform.Translate(1.0f, 0.0f, 0.0f);
        }
    }

    void FixedUpdate()
    {
        //change input based on player
        if (gameObject.tag == "p1")
        {
            move = Input.GetAxis("Player1");
        } else
        {
            move = Input.GetAxis("Player2");
        }

        float translation = move * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

          
    }
}
