using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempo;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vida;
    public GameObject Gameover;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo.text = Time.time.ToString("00.00");
        puntuacion.text = GameManager.instance.puntuacion.ToString("0000");
        vida.text = GameManager.instance.vida.ToString("0");
        if(GameManager.instance.vida <= 0) 
        {
            Gameover.SetActive(true);
        }
    }
}
