using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoTemblor : MonoBehaviour
{
    public CamaraTemblor camaraTemblor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camaraTemblor.Shake();
        }
    }
}
