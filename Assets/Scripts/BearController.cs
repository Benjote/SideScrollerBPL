using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    public int speed;
    public float visionRange = 5f;
    public float deathFallSpeed = 3f;

    private bool isDead = false;
    private bool isMovingRight = false;
    private Transform player; // Variable corregida

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Buscar y asignar el transform del jugador
        StartCoroutine(MoveRoutine());
    }

    private void Update()
    {
        if (!isDead)
        {
            if (IsPlayerInVisionRange())
            {
                ChasePlayer();
            }
            else
            {
                transform.Translate(Vector2.right * (isMovingRight ? 1 : -1) * speed * Time.deltaTime);
            }
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            transform.Translate(Vector2.down * deathFallSpeed * Time.deltaTime);

            if (transform.position.y < -10f)
            {
                Destroy(gameObject);
            }
        }
    }

    private bool IsPlayerInVisionRange()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) <= visionRange)
        {
            return true;
        }
        return false;
    }

    private void ChasePlayer()
    {
        if (player != null)
        {
            if (player.position.x < transform.position.x)
            {
                isMovingRight = false;
            }
            else
            {
                isMovingRight = true;
            }

            transform.Translate(Vector2.right * (isMovingRight ? 1 : -1) * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
                isMovingRight = !isMovingRight;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}