using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour {

    public float speed;
    private float p1x;
    private float p2x;
    private float tetherY;

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
        float translation = speed;
        translation *= Time.deltaTime;
        transform.Translate(0, translation, 0);
    }
}
