using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuntosEXP : MonoBehaviour
{
    public TMP_Text texto;
    private int puntosConfianza = 0;
    private int puntosHabilidadSocial = 0;
    private void Start()
    {
        ConfianzaTexto();
    }

    public void Confianza(int puntos)
    {
        puntosConfianza += puntos;
        ConfianzaTexto();
    }

    private void ConfianzaTexto()
    {
        texto.text = "Confianza: +" + puntosConfianza.ToString();
    }

    public void HabilidadSocial(int puntos)
    {
        puntosHabilidadSocial += puntos;
        HabilidadSocialTexto();
    }

    private void HabilidadSocialTexto()
    {
        texto.text = "Habilidad social: +" + puntosHabilidadSocial.ToString();
    }


}
