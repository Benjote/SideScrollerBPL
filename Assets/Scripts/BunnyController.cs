using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public int speed;
    public float deathFallSpeed = 3f;

    private bool isDead = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            transform.Translate(Vector2.down * deathFallSpeed * Time.deltaTime);

            if (transform.position.y < -10f)
            {
                // Si el objeto está fuera de la pantalla, destruirlo
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Player"))
        {
            // Obtener la dirección relativa de la colisión
            Vector2 relativeDirection = collision.contacts[0].point - (Vector2)transform.position;

            // Verificar si la colisión es desde arriba
            if (relativeDirection.y > 0)
            {
                // Realizar la animación de muerte
                isDead = true;
                GetComponent<Rigidbody2D>().gravityScale = 1f;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}