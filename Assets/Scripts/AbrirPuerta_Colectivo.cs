using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta_Colectivo : MonoBehaviour
{
    private Animator animacion;

    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    void Update()
    {
        AbrirPuerta();
    }

    public void AbrirPuerta()
    {
        animacion.enabled = true;
        //GetComponent<BoxCollider>().enabled = false;
    }
}
