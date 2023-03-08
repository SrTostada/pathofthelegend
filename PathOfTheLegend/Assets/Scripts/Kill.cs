using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    JhonMove pm;
    GruntScript am;

    private void Start() {

        pm = FindObjectOfType<JhonMove>();
    }
     
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player")) {

            pm.resetPosition();
            pm.Hit();

        }else Destroy(gameObject);


    }
}
