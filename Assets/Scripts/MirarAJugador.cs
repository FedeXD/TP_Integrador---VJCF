using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarAJugador : MonoBehaviour
{
    private Animator animacion;

    void Start()
    {
        animacion = GetComponent<Animator>();
    }

    void Update()
    {
        MirarJugador();
    }

    public void MirarJugador()
    {
        animacion.enabled = true;
    }
}