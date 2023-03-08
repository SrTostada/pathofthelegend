using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{

    public GameObject Jhon; 


    void Update()
    {
        if (Jhon == null) return;
        Vector3 pposition = transform.position;
        pposition.x = Jhon.transform.position.x;
        transform.position = pposition;
    }
}
