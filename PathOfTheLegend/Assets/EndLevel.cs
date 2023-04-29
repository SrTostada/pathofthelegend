using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Caballero") || collision.gameObject.CompareTag("Asesino") || collision.gameObject.CompareTag("Mago"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

}