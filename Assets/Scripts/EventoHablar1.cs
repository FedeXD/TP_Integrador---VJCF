using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventoHablar1 : MonoBehaviour
{
    private Canvas canvas;

    private void Start()
    {
        // Buscar un objeto Canvas en todos los recursos, incluidos los objetos inactivos
        Canvas[] canvases = Resources.FindObjectsOfTypeAll<Canvas>();

        foreach (Canvas foundCanvas in canvases)
        {
            if (foundCanvas.gameObject.name == "CanvasAlterno")
            {
                // Se encontró el Canvas deseado
                canvas = foundCanvas;
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JugadorController jugador = FindObjectOfType<JugadorController>();
            jugador.GetComponent<Rigidbody>().isKinematic = true;
            jugador.enabled = false;
            canvas.gameObject.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            Cursor.lockState = CursorLockMode.None;

        }           
    }
  
}
