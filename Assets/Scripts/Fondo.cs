using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    Rigidbody2D rb;
    public float Velocidadfondo = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(2,0);
        direccion = direccion * Velocidadfondo;
        rb.AddForce(direccion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
