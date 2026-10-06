using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ecomove : MonoBehaviour
{
    //private const int V = 2;
    public float Speed;
    public AudioClip lost;
    public AudioClip kick;
    public GameObject Eco;
    public float JumpForce;
    private bool Grounded;
    private Animator Animator;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public int vida = 3;
    public int Cb = 0;
    public camara n;
    public letrero1 L;
    public contadores Vida;
    public ContBasura ba;
    public arbol tree;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        n = FindObjectOfType<camara>();
        L = FindObjectOfType<letrero1>();
        Vida = FindObjectOfType<contadores>();
        Eco.gameObject.SetActive(true);
        ba = FindObjectOfType<ContBasura>();
    }

   
    void Update()
    {
         if(n.next >= 9 && L.Letrero1 == true){

            Horizontal = Input.GetAxisRaw("Horizontal");
            Animator.SetBool("Bool", Horizontal != 0.0f);
            

            if(Horizontal < 0.0f ){
                transform.localScale = new Vector3(-0.3f, 0.3f, 1.0f);
                
            }else if(Horizontal > 0.0f){
                transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
            }

            if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f)){
                Grounded = true;
            }else{
                Grounded = false;
            }

            if(Input.GetKeyDown(KeyCode.W) && Grounded == true){
                Jump();
            }
        }
    }

     private void Jump(){
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
     }


    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed, Rigidbody2D.velocity.y);
    }

    public void Hit(){
        if (vida != 1){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(kick);
        }
        vida -= 1;
        Vida.CambioVida(vida);
       SpriteRenderer.color = Color.red;
       StartCoroutine("Tiempo");
        if(vida == 0){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(lost);
            Eco.gameObject.SetActive(false);
        }
    }
    public void basura(){
        Cb += 1;
        ba.CambioBasura(Cb);
        if(n.SiguienteNivel == 2){
            Speed -= 0.3f;
            JumpForce -= 30;
        }
    }
    IEnumerator Tiempo(){
        yield return new WaitForSeconds(.05f);
        SpriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(.05f);
        SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.05f);
        SpriteRenderer.color = Color.white;
    }
    public void Position2(){
       transform.localPosition = new Vector3(0f, -6f, 1.0f);
    }
    public void posicion3(){
        transform.localPosition = new Vector3(0f, -12.5f, 1.0f);

    }
    public void posicionFinal(){
        transform.localPosition = new Vector3(0f, -15.5f, 1.0f);
        
    }
}