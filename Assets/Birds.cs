using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public GameObject[] referencePlanes;
    public Material[] birdsMats;
    public float setTimer = 10;
    public GameObject bird;
    float timer;
    Vector3 birdPos;

    void Start()
    {
        timer = setTimer;
        setBird();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            bird.transform.position = birdPos;
        }
        else
        {
            timer = setTimer;
            setBird();
        }
    }

    void setBird()
    {
        int refPlane = Random.Range(0, referencePlanes.Length);
        float birdZ = referencePlanes[refPlane].transform.position.z;
        float birdX = Random.Range(referencePlanes[refPlane].transform.position.x - referencePlanes[refPlane].transform.localScale.x * 5, referencePlanes[refPlane].transform.position.x + referencePlanes[refPlane].transform.localScale.x * 5);
        float birdY = Random.Range(referencePlanes[refPlane].transform.position.y - referencePlanes[refPlane].transform.localScale.z * 5, referencePlanes[refPlane].transform.position.x + referencePlanes[refPlane].transform.localScale.z * 5);
        birdPos = new Vector3(birdX, birdY, birdZ);

        int birdMat = Random.Range(0, birdsMats.Length);
        bird.GetComponent<Renderer>().material = birdsMats[birdMat];
    }
}
