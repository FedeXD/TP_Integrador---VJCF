using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Vendedor : MonoBehaviour
{
    JugadorController jugador;
    public TMP_Text texto;
    private Canvas canvas;

    private void Start()
    {
        jugador = FindObjectOfType<JugadorController>();
        Canvas[] canvases = Resources.FindObjectsOfTypeAll<Canvas>();

        foreach (Canvas foundCanvas in canvases)
        {
            if (foundCanvas.gameObject.name == "Canvas")
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
            StartCoroutine(HolaEnumerator());
        }
    }

    public IEnumerator HolaEnumerator()
    {
        jugador.GetComponent<Rigidbody>().isKinematic = true;
        jugador.enabled = false;
        yield return new WaitForSeconds(1f);
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        texto.text = "Mucho gusto";
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        canvas.gameObject.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

}
