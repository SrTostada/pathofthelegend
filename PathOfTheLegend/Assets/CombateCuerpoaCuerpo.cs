using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCuerpoaCuerpo : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private Transform controladorGolpeEspecial;

    [SerializeField] private float radioGolpe;

    [SerializeField] private float dañoGolpe;

    [SerializeField] private float radioGolpeEspecial;

    [SerializeField] private float dañoGolpeEspecial;

    [SerializeField] private float tiempoEntreAtaques;

    [SerializeField] private float tiempoEntreAtaquesEspeciales;

    [SerializeField] private float tiempoSiguienteAtaque;

    [SerializeField] private float tiempoSiguienteAtaqueEspecial;


    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (tiempoSiguienteAtaque > 0) {

            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (tiempoSiguienteAtaqueEspecial > 0)
        {

            tiempoSiguienteAtaqueEspecial -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.K) && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
        if (Input.GetKeyDown(KeyCode.L) && tiempoSiguienteAtaqueEspecial <= 0)
        {
            GolpeEspecial();
            tiempoSiguienteAtaqueEspecial = tiempoEntreAtaquesEspeciales;
        }
    }

    private void Golpe() {

        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

       /* foreach (Collider2D colisionador in objetos) {

            if (colisionador.CompareTag("Enemigo")) {

                colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }

        }*/

    }


    private void GolpeEspecial()
    {

        animator.SetTrigger("GolpeEspecial");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpeEspecial.position, radioGolpeEspecial);

        /* foreach (Collider2D colisionador in objetos) {

             if (colisionador.CompareTag("Enemigo")) {

                 colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
             }

         }*/

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(controladorGolpeEspecial.position, radioGolpeEspecial);
    }
}
