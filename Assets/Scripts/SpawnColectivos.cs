using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColectivos : MonoBehaviour
{
    public GameObject[] colectivos;
    public float minSegundos;
    public float maxSegundos = 15f;
    public float minTiempoRepetir;
    public float maxTiempoRepetir;
    public Quaternion rotacionEspecifica; // Rotación específica que deseas aplicar al objeto

    private void Start()
    {
        Invoke("InstanciarObjeto", Random.Range(minSegundos, maxSegundos));
    }

    private void InstanciarObjeto()
    {
        Vector3 posicionSpawn = transform.position;
        int indiceAleatorio = Random.Range(0, colectivos.Length); // Genera un índice aleatorio para seleccionar un objeto del array
        GameObject objetoAleatorio = colectivos[indiceAleatorio];
        Instantiate(objetoAleatorio, posicionSpawn, rotacionEspecifica);

        float tiempoAleatorio = Random.Range(minTiempoRepetir, maxTiempoRepetir);
        Invoke("InstanciarObjeto", tiempoAleatorio);
    }

}
