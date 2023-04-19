using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject Jhon;
    private float LastShoot;
    public float Health = 1;

    // Update is called once per frame
    void Update()
    {
        if (Jhon == null) return;
        Vector3 direction = Jhon.transform.position - transform.position;

        if (direction.x >= 0.0f) transform.localScale = new Vector3(5.446998f, 5.731894f, 1.0f);
        else transform.localScale = new Vector3(-5.446998f, 5.731894f, 1.0f);

        float distance = Mathf.Abs(Jhon.transform.position.x - transform.position.x);

        if (distance < 4.0f && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 5.446998f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void TomarDaño(float daño)
    {
        Health -= daño;
        Debug.Log("Al Enemigo le quedan " + Health + " puntos de salud.");
        if (Health <= 0) Muerte();
    }

    private void Muerte()
    {
        Destroy(gameObject);
        GameObject player = GameObject.FindWithTag("Asesino");
        if (player != null)
        {
            player.SendMessage("PasivaAsesino");
        }
    }
}

