using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float Speed;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;
    void Start() {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    private void FixedUpdate() {
        Rigidbody2D.velocity = Direction * Speed;
        Destroy(gameObject, 0.68f);
    }
   

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Ecomove eco = collision.GetComponent<Ecomove>();
        BOX box = collision.GetComponent<BOX>();
        if(eco != null){
            eco.Hit();
            Destroy(gameObject);
        }
        if(box != null){
            Destroy(gameObject);
        }
        
    }
}
