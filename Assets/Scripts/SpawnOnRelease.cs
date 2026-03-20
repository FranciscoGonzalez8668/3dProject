using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnOnRelease : MonoBehaviour
{


    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject golfBall;

    [SerializeField] private float maxDistance = 30f;
    // Start is called before the first frame update
    void Start()
    {
        golfBall.transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        if(Vector3.Distance(golfBall.transform.position, spawnPoint.position) > maxDistance)
        {
            BallOutOfBounds();
        }

    }

    private void HandleInput()
    {
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetBall();
        }
    }


    private void ResetBall()
    {
        golfBall.transform.position = spawnPoint.position;
        golfBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        golfBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        golfBall.SetActive(true);
    }



    private void BallOutOfBounds()
    {
        golfBall.SetActive(false);
    }
}
