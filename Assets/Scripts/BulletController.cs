using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    public GameObject Sonidobala;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<AsteroidController>().Muerte();
            Destroy(gameObject);
            GameObject temp = Instantiate(Sonidobala);
            Destroy(temp, 1.3f);
        }
        if (collision.tag == "Nave")  //Hay que hacer el contador en el navecontroller
        {
            NaveController.instance.Vidasnave -= 1;
            Destroy(gameObject);
            GameObject temp = Instantiate(Sonidobala);
        }
    }
}
