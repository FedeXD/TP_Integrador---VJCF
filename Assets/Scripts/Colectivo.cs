using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectivo : MonoBehaviour
{

    public float forceMagnitude = 10f; // Magnitud de la fuerza aplicada
    public float brakeForceMagnitude = 5f; // Magnitud de la fuerza de frenado


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Acelerar();
    }

    public void Acelerar()
    {
        Vector3 forwardForce = transform.right * forceMagnitude * Time.deltaTime;
        rb.AddForce(forwardForce, ForceMode.Impulse);
    }

    public void Frenar()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Vector3 brakeForce = -rb.velocity.normalized * brakeForceMagnitude;
        rb.AddForce(brakeForce, ForceMode.Impulse);
    }

    
}
