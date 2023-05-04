using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateCuerpoaCuerpo : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private Transform controladorGolpeEspecial;

    [SerializeField] private float radioGolpe;

    [SerializeField] public float dañoGolpe;

    [SerializeField] private float radioGolpeEspecial;

    [SerializeField] public float dañoGolpeEspecial;

    [SerializeField] private float tiempoEntreAtaques;

    [SerializeField] private float tiempoEntreAtaquesEspeciales;

    [SerializeField] private float tiempoSiguienteAtaque;

    [SerializeField] private float tiempoSiguienteAtaqueEspecial;

    [SerializeField] private AudioSource Ataque1Asesino;
    [SerializeField] private AudioSource Ataque2Asesino;

    [SerializeField] public float contadorGolpe=0;




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
            Ataque1Asesino.Play();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
            contadorGolpe = contadorGolpe + 1;
            if (contadorGolpe >= 5)
            {
                GameObject player = GameObject.FindWithTag("Mago");
                if (player != null)
                {
                    player.SendMessage("PasivaMago");
                }
                contadorGolpe = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.L) && tiempoSiguienteAtaqueEspecial <= 0)
        {
            GolpeEspecial();
            Ataque2Asesino.Play();
            tiempoSiguienteAtaqueEspecial = tiempoEntreAtaquesEspeciales;
            contadorGolpe = contadorGolpe + 3;
            
            if (contadorGolpe >= 5)
            {
                GameObject player = GameObject.FindWithTag("Mago");
                if (player != null)
                {
                    player.SendMessage("PasivaMago");
                }
                contadorGolpe = 0;
            }
        }
    }

    private void Golpe() {

        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos) {

            if (colisionador.CompareTag("Enemy")) {

                colisionador.transform.GetComponent<GruntScript>().TomarDaño(dañoGolpe);
            }

        }

    }


    private void GolpeEspecial()
    {

        animator.SetTrigger("GolpeEspecial");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpeEspecial.position, radioGolpeEspecial);

         foreach (Collider2D colisionador in objetos) {

             if (colisionador.CompareTag("Enemy")) {

                 colisionador.transform.GetComponent<GruntScript>().TomarDaño(dañoGolpeEspecial);
             }

         }

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(controladorGolpeEspecial.position, radioGolpeEspecial);
    }

    
}
