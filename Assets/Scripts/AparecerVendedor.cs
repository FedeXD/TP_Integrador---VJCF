using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerVendedor : MonoBehaviour
{
    public GameObject vendedor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            vendedor.SetActive(true);
        }
    }

    void Update()
    {
        
    }


}
