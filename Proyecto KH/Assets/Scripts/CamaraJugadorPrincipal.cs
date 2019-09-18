using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraJugadorPrincipal : MonoBehaviour
{
    [SerializeField] GameObject personaje;
    [SerializeField] float distanciaX = 0f;
    [SerializeField] float distanciaY = 0f;
    [SerializeField] float distanciaZ = 10f;

    // LateUpdate actualiza cuando se hayan hecho todos los updates. Es conveniente que no se cambie para la cámara ;).
    void LateUpdate()
    {
        SeguirPersonaje();
    }

    void SeguirPersonaje()
    {
        transform.position = new Vector3 (
            personaje.transform.position.x + distanciaX,
            personaje.transform.position.y + distanciaY,
            personaje.transform.position.z + distanciaZ
            );
    }
}
