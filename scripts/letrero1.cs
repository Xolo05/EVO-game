using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letrero1 : MonoBehaviour
{
    public GameObject letrero;
    public GameObject letrero2;
    public GameObject letrero3;
    private camara n;
    public bool Letrero1;
    void Start()
    {
        letrero.gameObject.SetActive(true);
        n = FindObjectOfType<camara>();
        letrero2.gameObject.SetActive(true);  
    }

    void Update()
    {
        if(n.next >= 9){
            if(Input.GetKeyDown(KeyCode.Return)){
            letrero.gameObject.SetActive(false);
            Letrero1 = true;
            }
        
        }
        if(n.SiguienteNivel == 1){
            if(Input.GetKeyDown(KeyCode.Return)){
            letrero2.gameObject.SetActive(false);  
            }
        }else if(n.SiguienteNivel >= 2){
           if(Input.GetKeyDown(KeyCode.Return)){
            letrero3.gameObject.SetActive(false); 
        }
    }
    }
}
