using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    [SerializeField] private GameObject[] pieces;
    [SerializeField] private float explosionForce = 300f;

    [SerializeField] private float explosionRadius = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        Debug.Log("Break objecto: ");
        GetComponent<Collider>().enabled = false;
        foreach (GameObject piece in pieces)
        {
            piece.SetActive(true); 
            piece.transform.parent = null;
            Rigidbody rd = piece.GetComponent<Rigidbody>();
            rd.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            Destroy(piece, 2f);
        }

        gameObject.SetActive(false);
    }
}
