using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casa : MonoBehaviour
{
    public AudioClip win;
    public camara w;
    private int veces = 0;
    public ContBasura reinicio;
    public contadores vidas;
    public arbol tree;
    void Start()
    {
       w = FindObjectOfType<camara>();
        reinicio = FindObjectOfType<ContBasura>();
        vidas = FindObjectOfType<contadores>();
        tree = FindObjectOfType<arbol>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        Ecomove eco = collision.GetComponent<Ecomove>();
        if( eco != false && eco.Cb == 3){
            w.MisionComplete1();
            eco.Cb = 0;
            reinicio.CambioBasura(0);
            vidas.CambioVida(3);
            eco.vida = 3;
            veces++;
            Debug.Log(veces);
            if (veces == 1){
                Camera.main.GetComponent<AudioSource>().PlayOneShot(win);
                eco.posicionFinal();
            }
        }
    }
}
