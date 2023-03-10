using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f; // velocidad del movimiento del jugador
    public float jumpForce = 7f; // fuerza del salto del jugador
    private bool isGrounded; // bandera que indica si el jugador está tocando el suelo

    void Update()
    {
        // Permitir que el jugador salte si está tocando el suelo y presiona la tecla W
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Mover al jugador a la derecha si el usuario presiona la tecla D
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Mover al jugador a la izquierda si el usuario presiona la tecla A
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Comprobar si el jugador está tocando el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
    }
}