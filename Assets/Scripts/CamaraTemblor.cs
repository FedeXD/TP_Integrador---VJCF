using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTemblor : MonoBehaviour
{
    public float shakeDuration = 0.5f; // Duración del temblor de la cámara
    public float shakeMagnitude = 0.1f; // Magnitud del temblor de la cámara

    private float shakeTimer = 0f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            // Generar una posición aleatoria dentro de un rango especificado
            Vector3 randomPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude * Time.deltaTime;

            // Aplicar la posición aleatoria a la cámara
            transform.localPosition = randomPosition;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            shakeTimer = 0f;
            transform.localPosition = originalPosition;
        }
    }

    public void Shake()
    {
        shakeTimer = shakeDuration;
    }
}
