using UnityEngine;

public class DeathW : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Caballero"))
        {
            Movev2 player = collision.gameObject.GetComponent<Movev2>();
            if (player != null)
            {
                player.Hit();
                player.transform.position = player.InitialPosition;
            }
        }
    }
}
