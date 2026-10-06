using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContBasura : MonoBehaviour
{
    public Sprite[] numeros;

    void Start()
    {
        CambioBasura(0);
    }

    
    void Update()
    {
        
    }
      public void CambioBasura(int pos)
    {  
        this.GetComponent<Image>().sprite = numeros[pos];
    }
}
