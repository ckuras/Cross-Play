using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float lb;
    private float rb;

    private float move;
    public float speed;

    void Start ()
    {
        GameObject score = GameObject.Find("ScoreTracker");
        ScoreTracker scoreTracker = score.GetComponent<ScoreTracker>();

        speed = 5.0f;

        lb = scoreTracker.leftBounds;
        rb = scoreTracker.rightBounds;

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

        if (gameObject.transform.position.x < lb){
            float diff = lb - gameObject.transform.position.x;
            transform.Translate(diff, 0, 0);
        }
        if (gameObject.transform.position.x > rb)
        {
            float diff = rb - gameObject.transform.position.x;
            transform.Translate(diff, 0, 0);
        }


    }
}
