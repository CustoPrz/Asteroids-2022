using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{
    public int speed = 0;
    Rigidbody2D rb;
    public float limiteizquierda = -7;
    public float limitederecha = 7;
    public float timer = 2;
    public int waitingTime = 0;
    public GameObject BalaNave;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 direccion = new Vector2(Random.Range(-1f, 1f),0);
        direccion = direccion * speed;
        rb.AddForce(direccion);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
            {
            Debug.Log("Han pasado dos segundos");
            GameObject temp = Instantiate(BalaNave,transform.position, transform.rotation);
            Destroy(temp, 2.5f);
            timer = 0;
            }
        if (transform.position.x > limitederecha)
            {
            Debug.Log("Hola derecha");
            parada();
            Vector2 direccion = new Vector2(-0.2f, 0);
            rb.AddForce(direccion*speed);
            }
        if (transform.position.x < limiteizquierda)
            {
            Debug.Log("Hola izquierda");
            parada();
            Vector2 direccion = new Vector2(0.2f, 0);
            rb.AddForce(direccion*speed);
            
            }



        

    }
    public void Muerte()
    {
      
        GameManager.instance.puntuacion += 300;
        Destroy(gameObject);

    }
    void parada()
    {
        Debug.Log("Estoy siendo parado");
        rb.velocity = Vector3.zero;
    }
}
