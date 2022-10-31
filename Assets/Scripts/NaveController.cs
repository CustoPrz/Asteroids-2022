using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public int Puntuacion = 0;
    public GameObject nave;
    public int Conteonave = 0;
    public int limitX = 6;
    public int Y = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.puntuacion == Puntuacion && (Conteonave ==0))
        {
            Crearufo();
        }
    }
    void Crearufo()
    {
        Vector3 posicionufo = new Vector3(Random.Range(-limitX, limitX), Y);
        GameObject temp = Instantiate(nave,posicionufo,Quaternion.identity);
        Conteonave += 1;
    }
}
