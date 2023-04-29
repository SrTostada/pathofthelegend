using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Movev2 player; // referencia al script de Movev2 del personaje
    private TextMeshProUGUI text; // referencia al componente TextMeshProUGUI del objeto

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = " Salud: " + player.Health.ToString() + "   Vidas: " + player.Lives.ToString();

    }
}
