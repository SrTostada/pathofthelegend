using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarPersonaje : MonoBehaviour
{
    public void CambiarEscena(string Selecciondepersonaje)
    {
        SceneManager.LoadScene(Selecciondepersonaje);
    }
}
