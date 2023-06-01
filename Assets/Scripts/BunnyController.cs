using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public int speed;
    public float deathFallSpeed = 3f;

    private bool isDead = false;
    private bool isMovingRight = false;

    private void Start()
    {
        // Iniciar movimiento hacia la derecha
        StartCoroutine(MoveRoutine());
    }

    private void Update()
    {
        if (!isDead)
        {
            transform.Translate(Vector2.right * (isMovingRight ? 1 : -1) * speed * Time.deltaTime);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            // Realizar la animación de muerte
            isDead = true;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);

            if (hit.collider != null && hit.collider.CompareTag("Walls"))
            {
                // Si choca con un objeto "Wall", cambiar dirección
                isMovingRight = !isMovingRight;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}