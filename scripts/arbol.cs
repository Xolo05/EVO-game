using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arbol : MonoBehaviour
{
    
    public AudioClip desplantar;
        void Start()
    {
        
    }
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ecomove eco = collision.GetComponent<Ecomove>();
        if (eco != false)
        {
            Camera.main.GetComponent<AudioSource>().PlayOneShot(desplantar);
            eco.basura();
            Destroy(gameObject);

        }
    }
}
