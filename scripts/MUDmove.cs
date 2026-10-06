using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MUDmove : MonoBehaviour
{
    public GameObject ECO2;
    private Animator Animator;
    private float LastShoot;
    public GameObject ProyectilPrefab;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    void Update() {
        if(ECO2 == null){
            return;
        }
        Vector3 direction = ECO2.transform.position - transform.position;
        if(direction.x >= 0.0f) transform.localScale = new Vector3(-.4f, .4f, .4f);
        else transform.localScale = new Vector3(.4f, .4f, .4f);

        float distanceJM = Mathf.Abs(ECO2.transform.position.x - transform.position.x);
        float distanceYM = Mathf.Abs(ECO2.transform.position.y - transform.position.y);


        if(distanceJM < 1.4f && distanceYM < 3.0f && Time.time > LastShoot + .6f){
            Shoot();
            LastShoot = Time.time; 
        }
         Animator.SetBool("MUD", distanceJM < 1.4f && distanceYM < 3.0f);

    }
        
    private void Shoot(){
        Vector3 direction;
        if(transform.localScale.x == -0.4f) direction = Vector2.right;
        else direction =  Vector2.left;

        GameObject Proyectil = Instantiate(ProyectilPrefab, transform.position + direction * 0.1f , Quaternion.identity);
        Proyectil.GetComponent<Proyectil>().SetDirection(direction);
    }

}
