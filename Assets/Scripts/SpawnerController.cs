using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public GameObject orbPrefab1;
    public GameObject orbPrefab2;

    private float rng;

    private float lb;
    private float rb;

    private bool move;
    public float speed;

    private bool spawn;

    private float spawnTime = 2.0f;
    private float cycleTime = 10.0f;

    float timer;
    float cycleTimer;

    // Use this for initialization
    void Start () {

        GameObject score = GameObject.Find("ScoreTracker");
        ScoreTracker scoreTracker = score.GetComponent<ScoreTracker>();

        move = true;
        speed = 1.0f;

        lb = scoreTracker.leftBounds;
        rb = scoreTracker.rightBounds;

    }
	
	// Update is called once per frame
	void Update () {

        rng = Random.Range(-1.0f, 1.0f);

        GameObject orb;

        if (rng > 0f)
        {
            orb = orbPrefab1;
        }
        else
        {
            orb = orbPrefab2;
        }
        cycleTimer = 0f;

        if (move)
        {
            float translation = speed;
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
            if (gameObject.transform.position.x < lb + 0.5f || gameObject.transform.position.x > rb - 0.5f)
            {
                speed *= -1.0f;
            }
        }

        timer += Time.deltaTime;
        cycleTimer += Time.deltaTime;

        // Time between orb spawns
        if (timer > spawnTime)
        {
            Instantiate(orb, gameObject.transform.position, Quaternion.identity);
            timer = 0f;
        }

        // time between new cycles
        if (cycleTimer > cycleTime)
        {
            if (rng > 0f)
            {
                orb = orbPrefab1;
            } else
            {
                orb = orbPrefab2;
            }
            spawnTime -= 0.1f;
            cycleTimer = 0f;
        }





    }
}
