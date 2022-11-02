using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class NaveController : MonoBehaviour
{
    public static NaveController instance;
    public int Puntuacion = 0;
    public GameObject nave;
    public int Conteonave = 0;
    public int limitX = 6;
    public float Y = 4;
    public int Vidasnave = 0;
    public float TiempoSpawnNave = 0;
    public float timer = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameManager.instance.puntuacion >= Puntuacion && (Conteonave == 0)&& (timer >= TiempoSpawnNave))
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
