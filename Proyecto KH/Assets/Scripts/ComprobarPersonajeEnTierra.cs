using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarPersonajeEnTierra : MonoBehaviour
{

    [SerializeField] bool personajeEnTierra; //DEBUG
    [SerializeField] float distanciaSuelo;

    [SerializeField] LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarEstado();
    }

    void ActualizarEstado()
    {
        //Debug.DrawRay(transform.position - new Vector3(0, 0.85f, 0), -transform.up, Color.red, distanciaSuelo);

        if (Physics.Raycast(transform.position - new Vector3(0,0.85f,0), -transform.up, distanciaSuelo, layer))
        {
            personajeEnTierra = true;
        }
        else
        {
            personajeEnTierra = false;
        }
    }

    public bool PersonajeEnTierra()
    {
        return personajeEnTierra;
    }
}
