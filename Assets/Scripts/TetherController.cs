using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherController : MonoBehaviour {

    public GameObject gameObject1;          // Reference to the first GameObject
    public GameObject gameObject2;          // Reference to the second GameObject

    private LineRenderer line;                           // Line Renderer

    private float p1x;
    private float p2x;

    public Color newGreen;
    public Color newYellow;

    // Use this for initialization
    void Start()
    {
        // Add a Line Renderer to the GameObject
        line = GetComponent<LineRenderer>();
        line.startWidth = 0.05f;

        

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player1 = GameObject.Find("Player1");
        PlayerController p1Controller = player1.GetComponent<PlayerController>();

        GameObject player2 = GameObject.Find("Player2");
        PlayerController p2Controller = player2.GetComponent<PlayerController>();

        p1x = p1Controller.transform.position.x;
        p2x = p2Controller.transform.position.x;

        // Check if the GameObjects are not null
        if (gameObject1 != null && gameObject2 != null)
        {
            // Update position of the two vertex of the Line Renderer
            line.SetPosition(0, gameObject1.transform.position);
            line.SetPosition(1, gameObject2.transform.position);
        }
        if (p1x < p2x)
        {
            line.startColor = newGreen;
            line.endColor = newGreen;
        } else if (p1x > p2x)
        {
            line.startColor = newYellow;
            line.endColor = newYellow;
        }

    }
}
