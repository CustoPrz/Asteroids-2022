using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    CircleCollider2D collider;
    SpriteRenderer sprite;
    public float speed = 10;
    public float rotationspeed = 0;
    public GameObject bala;
    public GameObject boca;
    public GameObject particulasMuerte;
    public bool muerto;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto==false)
       { 
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            
             rb.AddForce(transform.up * vertical * speed * Time.deltaTime);
             anim.SetBool("Impulso", true);
        }
        else
        {
            anim.SetBool("Impulso", false);
        }
        float horizontal = Input.GetAxis("Horizontal");
        transform.eulerAngles = transform.eulerAngles + new Vector3(0,0,horizontal* rotationspeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
           GameObject temp = Instantiate(bala, boca.transform.position, transform.rotation);
           Destroy(temp, 2.5f);
        }
       }
    }
    public void Muerte()
    {

        GameObject temp = Instantiate(particulasMuerte, transform.position, transform.rotation);
        Destroy(temp, 2.5f);
        if (GameManager.instance.vida == 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        else 
        { 
             StartCoroutine(Respawn_Coroutine());
        }
    }
    IEnumerator Respawn_Coroutine()
    {
        muerto = true;
        collider.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);
        collider.enabled = true;
        sprite.enabled = true;
        muerto = false;
        GameManager.instance.vida -= 1;
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);


        if (GameManager.instance.vida == 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            
            
        }
    }
}
