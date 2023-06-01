using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Cambiar el parámetro "Horizontal" en el Animator cuando el personaje se mueve
        animator.SetFloat("Horizontal", Mathf.Abs(moveInput));

        // Voltear el sprite si el personaje se mueve hacia la izquierda
        if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        // Voltear el sprite si el personaje se mueve hacia la derecha
        else if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Verificar si el personaje está en contacto con el suelo
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el círculo de verificación del suelo en el Editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}