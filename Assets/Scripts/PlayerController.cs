using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private CapsuleCollider2D collider;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(moveInput * speed * Time.deltaTime, 0f, 0f);

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
        // Restaurar la dirección del collider cuando el personaje no se está moviendo
        else
        {
            collider.direction = CapsuleDirection2D.Vertical;
        }
    }
}
