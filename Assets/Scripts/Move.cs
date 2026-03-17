using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    [SerializeField]
    private Transform Destination;
    
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moverse hacia un destino especifico
        Vector3 direction = Destination.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed *Time.deltaTime);

        // Moverse siempre hacia adelante (hacia donde mira el objeto)
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
