using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoPeaton : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints que seguir� el peat�n
    public float velocidadMinima = 1f; // Velocidad m�nima de movimiento del peat�n
    public float velocidadMaxima = 3f; // Velocidad m�xima de movimiento del peat�n

    private int waypointIndex = 0; // �ndice del waypoint actual
    private float velocidadActual; // Velocidad actual del peat�n
    private NavMeshAgent navMeshAgent; // Componente NavMeshAgent para la navegaci�n

    private Quaternion rotacionInicial; // Rotaci�n inicial del peat�n

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Obtener el componente NavMeshAgent
        velocidadActual = Random.Range(velocidadMinima, velocidadMaxima); // Generar una velocidad aleatoria al inicio

        // Guardar la rotaci�n inicial
        rotacionInicial = transform.rotation;

        SetDestination(); // Establecer el primer waypoint como destino inicial
    }

    private void Update()
    {

        // Verificar si se ha llegado al destino actual
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            // Avanzar al siguiente waypoint
            waypointIndex++;

            // Verificar si se ha llegado al �ltimo waypoint y reiniciar el ciclo
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }

            SetDestination(); // Establecer el siguiente waypoint como destino
        }
    }

    private void SetDestination()
    {
        // Restaurar la rotaci�n inicial
        transform.rotation = rotacionInicial;

        // Obtener la posici�n del waypoint actual
        Vector3 targetPosition = waypoints[waypointIndex].position;

        // Establecer el destino en el componente NavMeshAgent
        navMeshAgent.SetDestination(targetPosition);

        // Configurar la velocidad en el componente NavMeshAgent
        navMeshAgent.speed = velocidadActual;
    }
}
