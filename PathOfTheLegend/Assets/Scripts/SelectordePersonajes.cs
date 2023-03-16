using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectordePersonajes : MonoBehaviour
{
    public void EscogerPersonaje(string Selecciondepersonaje)
    {
        SceneManager.LoadScene(Selecciondepersonaje);
    }
}
