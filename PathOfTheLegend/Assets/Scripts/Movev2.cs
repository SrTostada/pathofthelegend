using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movev2 : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float Vertical;
    private float HorizontalD;
    private bool Grounded;
    public int Health = 5;
    private int Lives = 3; // variable para almacenar el número de vidas disponibles
    private Vector3 InitialPosition; // variable para guardar la posición inicial del personaje

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        InitialPosition = transform.position; // guardar la posición inicial
        
    }
    

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        HorizontalD = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (HorizontalD < 0.0f) transform.localScale = new Vector3(-1.2332f, 1.3883f, 1.0000f);
        else if (HorizontalD > 0.0f) transform.localScale = new Vector3(1.2332f, 1.3883f, 1.0000f);

        Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("jump", Vertical > 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1000000f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    public void Hit()
    {
        Health = Health - 1;
        Debug.Log("Te queda " + Health + " puntos de salud.");

        if (Health == 0)
        {
            // Si el personaje muere y aún tiene vidas disponibles, se resta una vida y se reinicia su salud
            if (Lives > 0)
            {
                Lives--;
                Health = 5;
                Debug.Log("Te quedan " + Lives + " vidas.");
                transform.position = InitialPosition; // establecer la posición del personaje como la posición inicial
            }
            else
            { // Si el personaje no tiene más vidas, se destruye
                Destroy(gameObject);
            }
        }
    }

    public void PasivaAsesino() {
        Health = Health + 1;
        Debug.Log("Te has curado un punto de vida, tu vida es " + Health);
    }
}
