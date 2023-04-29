
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Caballero") || collision.gameObject.CompareTag("Asesino") || collision.gameObject.CompareTag("Mago"))
        {
            Movev2 player = collision.gameObject.GetComponent<Movev2>();
            if (player != null)
            {
                if (player.InitialPosition != null)
                {
                    player.InitialPosition = transform.position;
                }
                else
                {
                    Debug.LogError("InitialPosition is null");
                }
            }
            else
            {
                Debug.LogError("Movev2 component is missing");
            }
        }


    }



}
