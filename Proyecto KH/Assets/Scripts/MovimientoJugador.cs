using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Range (0, 250)] [SerializeField] float velocidad = 10f;
    [SerializeField] bool mirarHaciaMovimiento = true; //Para poder desactivarlo si es necesario. (Ejemplo una animación concreta de batalla).
    [SerializeField] float salto = 10f;

    [SerializeField] bool usarGravedadCustom = true;

    bool saltando = false;

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        Comprobaciones();
    }

    void FixedUpdate()
    {
        if (usarGravedadCustom)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().AddForce(Physics.gravity * (GetComponent<Rigidbody>().mass * GetComponent<Rigidbody>().mass));
        }
    }

    void Movimiento()
    {
        Rigidbody player = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        //Movimiento Horizontal
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (!saltando)
            {
                GetComponent<Animator>().SetBool("AndandoHaciaAdelante", true);
            }
            player.transform.position += movement * velocidad * Time.deltaTime;

            if (mirarHaciaMovimiento)
            {
                transform.rotation = Quaternion.LookRotation(movement); //Mira hacia dónde anda.
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("AndandoHaciaAdelante", false);
        }

        //Salto
        if (Input.GetAxisRaw("Jump") != 0)
        {
            GetComponent<Animator>().SetBool("Saltar", true);
            if (!saltando)
            {
                player.AddForce(0, salto, 0, ForceMode.Impulse);
                saltando = true;
            }

            if (mirarHaciaMovimiento)
            {
                transform.rotation = Quaternion.LookRotation(movement); //Mira hacia dónde anda.
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Saltar", false);
        }
     
        if (FindObjectOfType<ComprobarPersonajeEnTierra>().PersonajeEnTierra())
        {
            saltando = false;
        }
    }

    private void Comprobaciones()
    {
        if (saltando)
        {
            GetComponent<Animator>().SetBool("Saltar", true);
        }
    }

    private void VelocidadPersonaje()
    {

    }

    public void MirarHaciaMovimiento(bool mirar) //Parar mirar o no hacia dónde nos movemos. Llamarlo desde scripts externos para activar y desactivar. (Ejemplo en una animación de batalla concreta)
    {
        mirarHaciaMovimiento = mirar;
    }



}
