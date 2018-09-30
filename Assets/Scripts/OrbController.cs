using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour {

    public float speed;
    private float p1x;
    private float p2x;
    private float tetherY;
    private SpriteRenderer sr;
    private Color color;
    private Color tetherColor;
    



    // Use this for initialization
    void Start () {

        GameObject player1 = GameObject.Find("Player1");
        PlayerController p1Controller  = player1.GetComponent<PlayerController>();

        GameObject player2 = GameObject.Find("Player2");
        PlayerController p2Controller = player2.GetComponent<PlayerController>();

        p1x = p1Controller.transform.position.x;
        p2x = p2Controller.transform.position.x;

        tetherY = p1Controller.transform.position.y;

        speed = -2.0f;


	}
	
	// Update is called once per frame
	void Update () {

        bool stopped = false;
        bool scored = false;

        sr = gameObject.GetComponent<SpriteRenderer>();
        color = sr.color;

        GameObject tether = GameObject.Find("Tether");
        LineRenderer lr = tether.GetComponent<LineRenderer>();
        TetherController tetherController = tether.GetComponent<TetherController>();

        tetherColor = lr.endColor;

        GameObject score = GameObject.Find("ScoreTracker");
        ScoreTracker scoreTracker = score.GetComponent<ScoreTracker>();

        GameObject player1 = GameObject.Find("Player1");
        PlayerController p1Controller = player1.GetComponent<PlayerController>();

        GameObject player2 = GameObject.Find("Player2");
        PlayerController p2Controller = player2.GetComponent<PlayerController>();

        p1x = p1Controller.transform.position.x;
        p2x = p2Controller.transform.position.x;

        float distance = Vector3.Distance(p1Controller.transform.position, p2Controller.transform.position);

        // Move orb down screen
        float translation = speed;
        translation *= Time.deltaTime;
        transform.Translate(0, translation, 0);

        // destroy orb if it cross tether
        if (transform.position.y < tetherY)
        {
            if (color == tetherController.newGreen && transform.position.x > p1x && transform.position.x < p2x)
            {
                stopped = true;
            }
            if (color == tetherController.newYellow && transform.position.x < p1x && transform.position.x > p2x)
            {
                stopped = true;
            }
        }

        if (stopped)
        {
            scoreTracker.score += (1000.0f * (1/distance));
            stopped = false;
            scored = true;
        }
        if (scored)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
}
