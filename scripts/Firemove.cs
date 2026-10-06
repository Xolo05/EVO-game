using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firemove : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private bool Grounded;
    public float Speed;
    public float rotar = 0.2f;
    public float height = 0.2f;
    private bool colicion;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Translate(Speed,0,0);
         if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f)){
            Grounded = true;
         }else{
            Grounded = false;
         }
        
        if(Grounded == false || colicion == true){
            rotar = rotar * -1;
            transform.localScale = new Vector3(rotar, height, 1.0f);
            Speed = Speed * -1;
            colicion = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BOX box = collision.GetComponent<BOX>();
        Ecomove eco = collision.GetComponent<Ecomove>();
        if (eco != null)
        {
            eco.Hit();
        }
         if(box != null){
             colicion = true;
        }
    }



}
