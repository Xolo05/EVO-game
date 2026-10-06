using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camara : MonoBehaviour{  
    public GameObject ECO;
    private bool history = true;
    public GameObject Image;
    public Ecomove siguiente;
    public GameObject boton;
    public GameObject arbol;
    private int regresar = 0;
    public GameObject basura;
    public GameObject contadorB;
    public int next = 0;
    private float Yposition = 80;
    private float extra = 0;
    public int SiguienteNivel = 0;
    private bool DejarDeSeguir = false;
    public letrero1 letrero;
    void Start(){
        siguiente = FindObjectOfType<Ecomove>(); 
        letrero = FindObjectOfType<letrero1>(); 
    }
     void Update() {  

        if (history == true){
            Image.gameObject.SetActive(false);
            boton.gameObject.SetActive(false);
            basura.gameObject.SetActive(false);
            contadorB.gameObject.SetActive(false);
            arbol.gameObject.SetActive(false);
             Vector3 position1 = transform.position;
            position1.y = Yposition - (next * 10) + extra;
            transform.position = position1;
            if(Input.GetKeyDown(KeyCode.Return))next++; Debug.Log(next);
            if(next == 8) extra = 0.13f;
        }
        if(next >= 9){
            history = false;
            if(SiguienteNivel != 3){
            Image.gameObject.SetActive(true);
            basura.gameObject.SetActive(true);
            contadorB.gameObject.SetActive(true);
            }
        }
        if(ECO != null && DejarDeSeguir == false){
            Vector3 PositionX = transform.position;
            if(ECO.transform.position.x <= -1){
                PositionX.x = -1;
               
            }else if(ECO.transform.position.x >= 21.6f){
                PositionX.x = 21.6f; 
            }else{
                PositionX.x = ECO.transform.position.x;
                transform.position = PositionX;
            }
        }
        if(regresar == 0){
        if(SiguienteNivel == 1){
            regresar ++;
            Vector3 positionF = transform.position;
            positionF.y = -5.7f;
            transform.position = positionF;
            basura.gameObject.SetActive(false);
            boton.gameObject.SetActive(true);
         }
    }else if (regresar == 1){
        if(SiguienteNivel == 2){

            regresar ++;
            Vector3 positionF = transform.position;
            positionF.y = -11.3f;
            transform.position = positionF;
            boton.gameObject.SetActive(false);
            arbol.gameObject.SetActive(true);
            siguiente.posicion3();
        }
    }else if(regresar == 2){
        if(SiguienteNivel == 3){

            regresar ++;
            Vector3 positionF = transform.position;
            positionF.y = -16f;
            transform.position = positionF;
            boton.gameObject.SetActive(false);
            arbol.gameObject.SetActive(false);
            siguiente.posicionFinal();
            DejarDeSeguir = true;
            basura.gameObject.SetActive(false);
            Image.gameObject.SetActive(false);
            contadorB.gameObject.SetActive(false);
        }
    }
        if(Input.GetKeyDown(KeyCode.R)){
           ResetGame();
        }
    }
    
    public void MisionComplete1(){ 
        SiguienteNivel++;
    }
    public void ResetGame(){
       SceneManager.LoadScene("proyecto_coding");
    }
    
    
}