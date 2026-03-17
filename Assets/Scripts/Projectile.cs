using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 10f;


    private Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Target"))
    {
        collision.gameObject.GetComponent<Breakable>().Break();
        transform.position = startPosition;
    }
    else if (collision.gameObject.CompareTag("Piece"))
    {
        // ignorar, no hacer nada
    }
    else
    {
        transform.position = startPosition;
        Debug.Log("Projectile reset to start position");
    }
}
}
