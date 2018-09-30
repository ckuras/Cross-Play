using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

    public float leftBounds;
    public float rightBounds;

    public float score;

    // Use this for initialization
    void Start () {
        leftBounds = -3.0f;
        rightBounds = 3.0f;
        score = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(score);
	}
}
