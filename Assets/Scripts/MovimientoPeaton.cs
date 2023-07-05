using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoPeaton : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints que seguirá el peatón
    public float velocidadMinima = 1f; // Velocidad mínima de movimiento del peatón
    public float velocidadMaxima = 3f; // Velocidad máxima de movimiento del peatón

    private int waypointIndex = 0; // Índice del waypoint actual
    private float velocidadActual; // Velocidad actual del peatón
    private NavMeshAgent navMeshAgent; // Componente NavMeshAgent para la navegación

    private Quaternion rotacionInicial; // Rotación inicial del peatón

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Obtener el componente NavMeshAgent
        velocidadActual = Random.Range(velocidadMinima, velocidadMaxima); // Generar una velocidad aleatoria al inicio

        // Guardar la rotación inicial
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

            // Verificar si se ha llegado al último waypoint y reiniciar el ciclo
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }

            SetDestination(); // Establecer el siguiente waypoint como destino
        }
    }

    private void SetDestination()
    {
        // Restaurar la rotación inicial
        transform.rotation = rotacionInicial;

        // Obtener la posición del waypoint actual
        Vector3 targetPosition = waypoints[waypointIndex].position;

        // Establecer el destino en el componente NavMeshAgent
        navMeshAgent.SetDestination(targetPosition);

        // Configurar la velocidad en el componente NavMeshAgent
        navMeshAgent.speed = velocidadActual;
    }
}
