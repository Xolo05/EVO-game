using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Ecomove e;
    private Animator Animator;
    public AudioClip clik;
    void Start()
    {
        e = FindObjectOfType<Ecomove>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        BOX bola = collision.GetComponent<BOX>();
        Ecomove eco = collision.GetComponent<Ecomove>();
        Animator.SetBool("click", eco != null);
        Animator.SetBool("click", bola != null);
        if (eco != null)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(clik);
            eco.basura();
        }
        if( bola != null){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(clik);
            e.basura();  
        }
    }
}
