using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private new CapsuleCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(moveInput * speed * Time.deltaTime, 0f, 0f);

        // Cambiar el parámetro "Horizontal" en el Animator cuando el personaje se mueve
        animator.SetFloat("Horizontal", Mathf.Abs(moveInput));

        // Voltear el sprite si el personaje se mueve hacia la izquierda
        if (moveInput < 0)
        {
            collider.direction = CapsuleDirection2D.Horizontal;
            spriteRenderer.flipX = true;
        }
        // Voltear el sprite si el personaje se mueve hacia la derecha
        else if (moveInput > 0)
        {
            collider.direction = CapsuleDirection2D.Horizontal;
            spriteRenderer.flipX = false;
        }

    }
}
