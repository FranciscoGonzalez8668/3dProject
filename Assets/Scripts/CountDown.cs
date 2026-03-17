using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    private float countdownTime = 10f;

    [SerializeField]
    private float  velocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (countdownTime <= 0f)
        {
            countdownTime= 0f;
            Debug.Log("Game Over. You lost your mind");
        }else
        {
            countdownTime -= velocity * Time.deltaTime;
        }
    }
}
