using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventoParadaColectivo : MonoBehaviour
{
    public TMP_Text pulsarTecla;
    private JugadorController jugador;
    public GameObject Spawn_Colectivos;

    private void Start()
    {
        jugador = FindObjectOfType<JugadorController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pulsarTecla.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pulsarTecla.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(pulsarTecla.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            jugador.GetComponent<Rigidbody>().isKinematic = true;
            jugador.enabled = false;
            pulsarTecla.gameObject.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            Instantiate(Spawn_Colectivos);
        }
    }
}
