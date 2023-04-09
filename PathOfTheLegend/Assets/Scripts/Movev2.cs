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
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
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
}
