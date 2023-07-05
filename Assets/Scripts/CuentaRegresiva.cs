using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaRegresiva : MonoBehaviour
{
    
    public IEnumerator CuentaRegresivaEnumerate(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
    }
}
