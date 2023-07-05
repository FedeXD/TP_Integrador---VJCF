using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class PararColectivo : MonoBehaviour
{
    private JugadorController jugador;
    private Colectivo colectivo;
    private AbrirPuerta_Colectivo abrirPuerta;
    private bool jugadorEnColision = false;
    SpawnColectivos spawn_Colectivos;
    

    private void Start()
    {
        jugador = FindObjectOfType<JugadorController>();
        colectivo = FindObjectOfType<Colectivo>();
        abrirPuerta = FindObjectOfType<AbrirPuerta_Colectivo>();
        spawn_Colectivos = FindObjectOfType<SpawnColectivos>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnColision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnColision = false;
        }
    }

    private void Update()
    {
        if (jugadorEnColision && Input.GetButtonDown("Fire1"))
        {
            FrenarColectivo();
        }
    }

    private void FrenarColectivo()
    {
        StartCoroutine(FrenarColectivoEnumerator());
    }

    private IEnumerator FrenarColectivoEnumerator()
    {
        jugador.GetComponent<Rigidbody>().isKinematic = false;
        jugador.enabled = true;
        colectivo.Frenar();
        Destroy(spawn_Colectivos);
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        colectivo.enabled = false;
        yield return new WaitForSeconds(2f);
        abrirPuerta.enabled = true;
    }
}
