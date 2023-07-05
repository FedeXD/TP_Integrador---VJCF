using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respuestas : MonoBehaviour
{
    public GameObject[] Opciones;
    public PuntosEXP puntosEXP;
    public int puntosConfianza;
    public int puntosHabilidadSocial;
    public TMP_Text texto;
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

        puntosEXP = FindObjectOfType<PuntosEXP>();

    }

    public void Mirar()
    {
        StartCoroutine(MirarEnumerator());
    }
    public void TresPuntosSuspensivos()
    {
        StartCoroutine(TresPuntosSuspensivosEnumerator());
    }

    public void TresPuntosSuspensivos2()
    {
        StartCoroutine(TresPuntosSuspensivosEnumerator_2());
    }

    public void Hola()
    {
        StartCoroutine(HolaEnumerator());
    }

    public void Si()
    {
        StartCoroutine(SiEnumerator());
    }

    public void InserteDestino()
    {
        StartCoroutine(InserteDestinoEnumerator());
    }

    public void InserteDestinoAlternativo()
    {
        StartCoroutine(InserteDestinoEnumerator_Alternativo());
    }

    public void NoGracias()
    {
        StartCoroutine(NoGraciasEnumerator());
    }

    public void Salir()
    {
        StartCoroutine(SalirEnumerator());
    }

    public IEnumerator SalirEnumerator()
    {
        Opciones[3].gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        puntosEXP.enabled = true;
        puntosEXP.Confianza(puntosConfianza);
        yield return new WaitForSeconds(1f);
        puntosEXP.enabled = false;
        yield return new WaitForSeconds(1f);
        puntosEXP.enabled = true;
        puntosEXP.HabilidadSocial(puntosHabilidadSocial);
        yield return new WaitForSeconds(2f);
        //JugadorController jugador = FindObjectOfType<JugadorController>();
        //jugador.GetComponent<Rigidbody>().isKinematic = false;
        //jugador.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pagar()
    {
        StartCoroutine(PagarEnumerator());
    }

    public IEnumerator TresPuntosSuspensivosEnumerator_2()
    {
        JugadorController jugador = FindObjectOfType<JugadorController>();
        jugador.GetComponent<Rigidbody>().isKinematic = true;
        jugador.enabled = false;
        Opciones[0].gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Opciones[1].gameObject.SetActive(true);
        texto.gameObject.SetActive(false);
    }

    public IEnumerator TresPuntosSuspensivosEnumerator()
    {
        Opciones[0].gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        MirarAJugador[] mirarJugadores = FindObjectsOfType<MirarAJugador>();
        foreach (MirarAJugador mirarJugador in mirarJugadores)
        {
            mirarJugador.enabled = true;
        }
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Opciones[1].gameObject.SetActive(true);
        texto.gameObject.SetActive(false);
    }

    public IEnumerator HolaEnumerator()
    {
        Opciones[1].gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(true);
        texto.text = "Nunca te habíamos visto";
        yield return new WaitForSeconds(2f);
        texto.text = "¿Sos nuevo?";
        yield return new WaitForSeconds(3f);
        Opciones[2].gameObject.SetActive(true);
        texto.gameObject.SetActive(false);
    }

    public IEnumerator SiEnumerator()
    {
        Opciones[2].gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(true);
        texto.text = "¡Qué bueno, mucho gusto!";
        yield return new WaitForSeconds(3f);
        Opciones[3].gameObject.SetActive(true);
        texto.gameObject.SetActive(false);
    }

    public IEnumerator InserteDestinoEnumerator()
    {
        Colectivo colectivo = FindObjectOfType<Colectivo>();
        colectivo.enabled = false;
        Opciones[1].gameObject.SetActive(false);
        JugadorController jugador = FindObjectOfType<JugadorController>();
        jugador.GetComponent<Rigidbody>().isKinematic = true;
        jugador.enabled = false;
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(true);
        texto.text = "¡Muy bien!";
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(false); 
        jugador.GetComponent<Rigidbody>().isKinematic = false;
        jugador.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(2f);    
        colectivo.enabled = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator InserteDestinoEnumerator_Alternativo()
    {
        Colectivo colectivo = FindObjectOfType<Colectivo>();
        colectivo.enabled = false;
        Opciones[1].gameObject.SetActive(false);
        JugadorController jugador = FindObjectOfType<JugadorController>();
        jugador.GetComponent<Rigidbody>().isKinematic = true;
        jugador.enabled = false;
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(true);
        texto.text = "Disculpe, pero este colectivo no lleva hasta ahí";
        yield return new WaitForSeconds(2f);
        Opciones[2].gameObject.SetActive(true);
        texto.gameObject.SetActive(false);   
    }

    public IEnumerator NoGraciasEnumerator()
    {
        Opciones[1].gameObject.SetActive(false);
        texto.gameObject.SetActive(true);
        texto.text = "Pero por favor";
        yield return new WaitForSeconds(2f);
        texto.text = "Al menos para ayudar a la familia";
        yield return new WaitForSeconds(2f);
        texto.text = "Aunque sea paga con lo que tengas";
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(false);
        Opciones[2].gameObject.SetActive(true);
    }

    public IEnumerator MirarEnumerator()
    {    
        Opciones[0].gameObject.SetActive(false);
        texto.gameObject.SetActive(true);
        texto.text = "Bueno, te cuento";
        yield return new WaitForSeconds(2f);
        texto.text = "Acá, en esta canasta vendo cosas";
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(false);
        Opciones[1].gameObject.SetActive(true);
    }

    public IEnumerator PagarEnumerator()
    {
        Opciones[2].gameObject.SetActive(false);
        texto.gameObject.SetActive(true);
        texto.text = "Muchas gracias, amigo";
        yield return new WaitForSeconds(2f);
        texto.text = "Que Dios te bendiga";
        yield return new WaitForSeconds(2f);
        texto.gameObject.SetActive(false);
        Opciones[2].gameObject.SetActive(false);
        JugadorController jugador = FindObjectOfType<JugadorController>();
        jugador.GetComponent<Rigidbody>().isKinematic = false;
        jugador.enabled = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Bajarse()
    {    
        Opciones[2].gameObject.SetActive(false);
        JugadorController jugador = FindObjectOfType<JugadorController>();
        jugador.GetComponent<Rigidbody>().isKinematic = false;
        jugador.enabled = true;
        GameObject parada = GameObject.Find("Parada");
        parada.GetComponent<BoxCollider>().enabled = true;
        GameObject colectivo = GameObject.FindGameObjectWithTag("Colectivo");
        Destroy(colectivo);
        canvas.gameObject.SetActive(false);
        Opciones[0].SetActive(true);

    }


}
