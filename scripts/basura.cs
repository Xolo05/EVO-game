using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basura : MonoBehaviour
{
    public AudioClip punto;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        Ecomove eco = collision.GetComponent<Ecomove>();
        if( eco != false){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(punto);
            eco.basura();
            Destroy(gameObject);
            
        }
    }
    
}
