using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNaveContr : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    public GameObject Sonidobala;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 FuerzaBala = new Vector3(0, -1f);
        rb.AddForce(FuerzaBala * speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Muerte();
            Destroy(gameObject);
            GameObject temp = Instantiate(Sonidobala);
            Destroy(temp, 2.5f);
        }
    }
}